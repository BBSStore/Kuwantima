# Getting Started with Kuwantima

Welcome! This guide will walk you through copying the Kuwantima design system
and making it your own. No prior Git or GitHub experience required.

---

## What You Need

Install these first (all free):

1. **A GitHub account** — sign up at https://github.com/signup
2. **Git** — download from https://git-scm.com/downloads
   - Windows: run the installer and accept the defaults
3. **.NET 10 SDK** — download from https://dotnet.microsoft.com/download
4. **A code editor** — any of these work:
   - [Visual Studio](https://visualstudio.microsoft.com/) (full IDE, Windows/Mac)
   - [VS Code](https://code.visualstudio.com/) (lightweight, all platforms)
   - [JetBrains Rider](https://www.jetbrains.com/rider/) (full IDE, all platforms)

### Check that it worked

Open a terminal (Command Prompt, PowerShell, or Terminal) and run:

```
git --version
dotnet --version
```

You should see version numbers. If you get "command not found", restart your
terminal and try again.

---

## Step 1: Fork the project

"Forking" creates your own copy on GitHub. The original is unaffected by
anything you do.

1. Go to https://github.com/Votskwani/Kuwantima
2. Click the **Fork** button in the top right corner
3. On the next page, click **Create fork**

You now have your own copy at `github.com/YOUR-USERNAME/Kuwantima`.

---

## Step 2: Download it to your computer

On your fork's page, click the green **Code** button and copy the URL.

Open a terminal and run (replace `YOUR-USERNAME` with your GitHub username):

```
git clone https://github.com/YOUR-USERNAME/Kuwantima.git
cd Kuwantima
```

You now have all the project files on your computer.

---

## Step 3: Run it

Let's make sure everything works before changing anything:

```
dotnet run --project Kuwantima.Sandbox
```

A window will open showing the design system — buttons, toggles, sliders, all
styled with the glass-glow theme. Click around and explore! Close the window
when you're done.

---

## Step 4: Make your first change

Let's change a color so you can see the edit-run cycle in action.

1. Open the project folder in your code editor

2. Open this file:
   `Kuwantima/Theme/KuwantimaThemeResources.axaml`

3. Find `KuwantimaAccentBorder` — it controls the glow color on selected items

4. Change the hex color value to something you like
   (try `#FF6A0DAD` for purple or `#FF00CED1` for teal)

5. Save the file

6. Run the sandbox again:
   ```
   dotnet run --project Kuwantima.Sandbox
   ```

7. See your change! Toggle between light and dark mode to see it in both themes.

---

## Step 5: Save your change to GitHub

When you're happy with a change, save it with these three commands:

```
git add .
git commit -m "Change accent color"
git push
```

**What just happened:**
- `git add .` — selects all changed files
- `git commit -m "..."` — saves a snapshot with a short description
- `git push` — uploads it to your GitHub fork

Go to your fork on GitHub and refresh the page — you'll see your commit!

---

## Step 6: Keep going

Here's where to look depending on what you want to change:

| I want to... | Look in... |
|---|---|
| Change colors and themes | `Kuwantima/Theme/KuwantimaThemeResources.axaml` |
| Change how a button looks | `Kuwantima/Styles/KuwantimaButton.axaml` |
| Change how a checkbox looks | `Kuwantima/Styles/KuwantimaCheckBox.axaml` |
| Change any control's style | `Kuwantima/Styles/Kuwantima{ControlName}.axaml` |
| Add a demo page to the sandbox | `Kuwantima.Sandbox/Views/Pages/` |

The sandbox app is your playground — every time you change a style, run it to
see the result. There are no tests to run; if it looks right, it is right.

---

## Useful Git commands

You only need a handful of commands for day-to-day work:

| Command | What it does |
|---|---|
| `git status` | Shows what files you've changed |
| `git add .` | Stages all changes for commit |
| `git commit -m "message"` | Saves a snapshot |
| `git push` | Uploads to GitHub |
| `git pull` | Downloads latest changes from GitHub |
| `git log --oneline` | Shows recent commit history |

---

## Troubleshooting

**"DLL is locked" or build fails after running the sandbox**
Close the sandbox window before trying to build again.

**Git asks for my password every time**
Run this once to save your credentials:
```
git config --global credential.helper store
```
Or install [GitHub CLI](https://cli.github.com/) and run `gh auth login`.

**I broke something and want to start over**
You can always delete your local folder, go to your fork on GitHub, delete it,
and re-fork from the original. Clean slate, no harm done.

**I want to get updates from the original project**
```
git remote add upstream https://github.com/Votskwani/Kuwantima.git
git pull upstream master
```
This pulls in any new changes from the original Kuwantima repo.

---

## Project structure at a glance

```
Kuwantima/
  Theme/             -- colors, brushes, theme definitions
  Styles/            -- how each control looks
Kuwantima.Sandbox/   -- the demo app you run to see your changes
  Views/Pages/       -- each page in the sandbox
```

---

## License

Kuwantima is MIT licensed — you're free to use, modify, and distribute it.
Just keep the LICENSE file in your repo.

Happy building!
