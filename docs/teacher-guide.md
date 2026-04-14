# Teacher Guide — Helping Someone Fork Kuwantima

This guide is for you, the person walking a new GitHub user through forking
Kuwantima and making it their own. It assumes they have little or no Git/GitHub
experience. The companion doc (`getting-started.md`) is what you hand to them.

---

## Before You Start

Make sure they have these installed:

- [ ] **Git** — https://git-scm.com/downloads (Windows: use the installer defaults)
- [ ] **.NET 10 SDK** — https://dotnet.microsoft.com/download
- [ ] **A code editor** — Visual Studio, VS Code, or JetBrains Rider
- [ ] **A GitHub account** — https://github.com/signup

### Verify their setup

Have them open a terminal and run:

```
git --version
dotnet --version
```

Both should print a version number. If not, the installs aren't on their PATH yet
(restart the terminal or reinstall with "Add to PATH" checked).

---

## The Walkthrough

### 1. Forking (on GitHub)

Walk them through this on screen:

1. Open https://github.com/Votskwani/Kuwantima
2. Click the **Fork** button (top right corner)
3. On the "Create a new fork" page, they can rename the repo if they want
4. Click **Create fork**
5. They now have their own copy at `github.com/THEIR-USERNAME/Kuwantima`

**What to explain:** A fork is a full, independent copy. Nothing they do affects
the original. They own it. They can rename it, delete it, change everything.

### 2. Cloning (getting it on their computer)

On their fork's page, click the green **Code** button and copy the HTTPS URL.
Then in their terminal:

```
git clone https://github.com/THEIR-USERNAME/Kuwantima.git
cd Kuwantima
```

**What to explain:** Cloning downloads the repo to their machine. The folder it
creates is their local workspace — this is where they edit code.

### 3. Running the sandbox

Before they change anything, prove it works:

```
dotnet run --project Kuwantima.Sandbox
```

A window should appear showing the design system demo. Let them click around.
This is the visual test harness — whenever they change a style, they run this
to see the result.

**If it fails:** Check .NET version (`dotnet --version` — needs 10.0+).

### 4. Making a change together

Pick something visual and low-risk for their first edit. Good candidates:

- **Change an accent color** in `Kuwantima/Theme/KuwantimaThemeResources.axaml`
  — find `KuwantimaAccentBorder` and swap the hex color
- **Change a glow color** — find `KuwantimaGlowBrush` and try a different hue

Have them:
1. Open the file in their editor
2. Change one color value
3. Save
4. Run the sandbox again to see the difference

This builds confidence: edit, save, run, see.

### 5. Their first commit and push

Walk them through saving their change to GitHub:

```
git add .
git commit -m "Change accent color to purple"
git push
```

Then have them refresh their fork on GitHub — they'll see the commit appear.

**What to explain:**
- `git add` stages changes (selects what to include)
- `git commit` saves a snapshot with a message
- `git push` uploads it to GitHub

### 6. Making it their own (optional next steps)

Once they're comfortable, point them to these customization paths:

| Goal | Where to look |
|---|---|
| Change all colors | `Kuwantima/Theme/KuwantimaThemeResources.axaml` |
| Modify a control style | `Kuwantima/Styles/Kuwantima{Control}.axaml` |
| Add a new sandbox page | Follow the checklist in `CLAUDE.md` |
| Rename the project | Repo settings on GitHub + namespaces in code |
| Publish as their own NuGet package | Update `.csproj` metadata + set up their own API key |

---

## Common Stumbles

| Problem | Fix |
|---|---|
| "Permission denied" on push | They cloned your repo, not their fork. Re-clone from their fork URL. |
| "DLL is locked" on build | Close the sandbox window before rebuilding. |
| Git asks for credentials every time | Set up a credential helper: `git config --global credential.helper store` or use GitHub CLI (`gh auth login`). |
| They accidentally edit `master` | It's fine — they own the fork. No protection rules to worry about for solo work. |
| They want to pull your latest updates | `git remote add upstream https://github.com/Votskwani/Kuwantima.git` then `git pull upstream master` |

---

## Tone Tips

- Let them drive the keyboard. Resist the urge to type for them.
- Celebrate the first successful push — it's a real milestone.
- If something breaks, treat it as a learning moment, not a problem.
- "You can always re-fork" is a comforting safety net for beginners.
