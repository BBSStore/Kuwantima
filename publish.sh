#!/bin/bash
# ═══════════════════════════════════════════════════════════════════
# Kuwantima Publish Script
# ═══════════════════════════════════════════════════════════════════
# Usage:  ./publish.sh <version> [nuget-api-key]
#
# Before running, ensure you have:
#   1. Updated VERSION HISTORY in KuwantimaPrimaryTheme.axaml
#   2. Added version entry in DocumentsPage.axaml
#   3. Updated CLAUDE.md if checklists changed
#   4. Made all feature/fix changes
#
# This script will:
#   1. Update <Version> in Kuwantima.csproj
#   2. Commit all changes
#   3. Tag the commit
#   4. Push commit + tag to origin
#   5. Build NuGet package
#   6. Publish to nuget.org (if API key provided)
# ═══════════════════════════════════════════════════════════════════

set -e

VERSION="$1"
NUGET_KEY="$2"
REPO_ROOT="$(cd "$(dirname "$0")" && pwd)"
CSPROJ="$REPO_ROOT/Kuwantima/Kuwantima.csproj"

# ── Validate ──────────────────────────────────────────────────────
if [ -z "$VERSION" ]; then
    echo "Usage: ./publish.sh <version> [nuget-api-key]"
    echo "  e.g. ./publish.sh 1.1.0"
    echo "  e.g. ./publish.sh 1.1.0 oy2abc..."
    exit 1
fi

if ! echo "$VERSION" | grep -qE '^[0-9]+\.[0-9]+\.[0-9]+$'; then
    echo "Error: Version must be in format X.Y.Z (e.g. 1.1.0)"
    exit 1
fi

echo "═══════════════════════════════════════════════════════"
echo "  Kuwantima Publish — v$VERSION"
echo "═══════════════════════════════════════════════════════"

# ── Pre-flight checks ────────────────────────────────────────────
echo ""
echo "Pre-flight checklist:"
echo "  [ ] VERSION HISTORY updated in KuwantimaPrimaryTheme.axaml?"
echo "  [ ] Version entry added in DocumentsPage.axaml?"
echo "  [ ] README.md updated if needed?"
echo ""
read -p "Continue? (y/n) " -n 1 -r
echo ""
if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    echo "Aborted."
    exit 0
fi

# ── Step 1: Update .csproj version ───────────────────────────────
echo ""
echo "Step 1/6: Updating version in .csproj..."
sed -i "s|<Version>[^<]*</Version>|<Version>$VERSION</Version>|" "$CSPROJ"
echo "  → Kuwantima.csproj <Version> set to $VERSION"

# ── Step 2: Commit ───────────────────────────────────────────────
echo ""
echo "Step 2/6: Committing..."
cd "$REPO_ROOT"
git add -A
git commit -m "Release Kuwantima v$VERSION

Co-Authored-By: Claude Opus 4.6 <noreply@anthropic.com>"
echo "  → Committed"

# ── Step 3: Tag ──────────────────────────────────────────────────
echo ""
echo "Step 3/6: Tagging v$VERSION..."
git tag "v$VERSION"
echo "  → Tagged v$VERSION"

# ── Step 4: Push ─────────────────────────────────────────────────
echo ""
echo "Step 4/6: Pushing to origin..."
git push origin master
git push origin "v$VERSION"
echo "  → Pushed commit + tag"

# ── Step 5: Pack ─────────────────────────────────────────────────
echo ""
echo "Step 5/6: Building NuGet package..."
dotnet pack "$CSPROJ" -c Release
NUPKG="$REPO_ROOT/Kuwantima/bin/Release/Kuwantima.$VERSION.nupkg"
echo "  → Package: $NUPKG"

# ── Step 6: Publish (optional) ───────────────────────────────────
echo ""
if [ -n "$NUGET_KEY" ]; then
    echo "Step 6/6: Publishing to nuget.org..."
    dotnet nuget push "$NUPKG" --api-key "$NUGET_KEY" --source https://api.nuget.org/v3/index.json
    echo "  → Published! Package will be indexed in ~15 minutes."
else
    echo "Step 6/6: Skipped (no API key provided)"
    echo "  To publish manually:"
    echo "  dotnet nuget push \"$NUPKG\" --api-key YOUR_KEY --source https://api.nuget.org/v3/index.json"
fi

echo ""
echo "═══════════════════════════════════════════════════════"
echo "  Kuwantima v$VERSION — done!"
echo "═══════════════════════════════════════════════════════"
