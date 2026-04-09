# RPG Dungeon Crawler
This project is a top-down 2D Dungeon Crawler where you go through multiple randomised floors killing enemies.

Team will also try to add RPG elements like character and class selection, friendly/neutral characters and quests and also items and equipment.

Repo used: https://github.com/IndaPlus25/msorberg-korlot-project

Project manager used: https://github.com/orgs/IndaPlus25/projects/10

# Goals
The MVP should be focused on having:
- A controllable player
- A weapon to attack enemies
- Enemies (of a single type)
- Randomly generated rooms

If team have more time then they should focus on implementing:
- Title screen
- Settings
- Multiple weapons
- Multiple enemy types
- Multiple floors
- Looting weapons, equipment and consumables
- Inventory
- Rogue-like system
  - Cash system
  - Upgrades
- Audio system
- Pixel art graphics
- RPG system
  - Character selection
  - Class selection
  - Friendly/neutral characters
    - Attacks you if you attack them
    - If you attack too many they automatically attack you
  - Shopkeepers
  - Quests

# Releases
Every time a milestone is reached, a new release will be created. 

It will have it's own description and a version number.

- d = game is done
- m = milestone
- h = hotfix

Version number will be: **d.mhh**

So first milestone will be version v0.100.

If it has a hotfix it will be version v0.101, to have 99 hotfixes between milestones.

If the game is finally done it will be v1.000


# Collaboration
This big chapter will cover:
- Github projects
  - Kanban board
  - Roadmap
- Issues
- Commits
- Branches
- Pull Requests
- Unity
  - Variable Scope
  - Naming conventions
- Logs

## Github projects
Team will be using github projects for this project. Making use of its kanban board and roadmap.

### <ins>Kanban board:
Team will divide up the board into 7 different columns in the kanban board:
- Ideas
- Optional Implementations
- TODO
- In progress (Korlot)
- In progress (Msorberg)
- In review
- Complete

`Ideas` will have all the team's ideas that they haven't agreed upon yet or aren't sure would fit the game. 

If the team agree it's a good idea then it either moves into `TODO` or `Optional Implementations` depending on if they know they have to implement it or not.

`In progess (Korlot)` & `In progress (Msorberg)` is to keep track of what the other person is doing. When team have started working on an issue they pull that issue from `TODO` into their respective column to show the other team members that they started working on it. 

Once team are done they can move the issue into `In review`. Every issue needs to be reviewed by all members before it can be merged into `main`. 

After it's been reviewed and the issue have been merged to main it will finally be closed and automatically moved to `Complete`.

### <ins>Roadmap & Milestones:
Every friday team will create a milestone with issues to be fixed until next friday.

Every issue being worked on will be marked with that milestone to be easily shown in the roadmap and board.

It will have the format off `Week x: Description`, like for example `Week 3: Fix Specification`.

## Issues
Team will be using future tense and capital letter in the beginning, like `Fix this bug`, to follow Github Standard.

One issue will cover a pretty big category of issues, some examples of a big category is `Add a player`, `Add weapons` or `Add random room generation`.

Subissues like `Add jump` or `Create rooms` will be put inside the description of that issue with a checkbox. 

The description will also have a quick description to explain which type of issues it will solve.
### <ins>Example:
### Add a player #1
Create a player
- [ ] Add jump

## Commits
Commits will also use future tense and capital letters, like `Add enemy`.

## Branches
One branch will be created for each issue. 

The branch name will have the issue number and the feature described in a few words and in kebab-case, like `6-player`, `4-enemy`, `13-weapons` or `15-random-room-generation`.

Once one of the features are completed they will be merged to main using pull requests.

Once the branch has been merged it can be closed once it's been updated and tested for obvious bugs. For files that needs constant updating, like this document, the branch can be kept open.

If team find new problems/bugs, a new issue is created and a new branch with the number of that issue.

## Pull requests
When team is done with their feature they will use pull requests to merge to main.

The review of that pull request will be done by the other person. 

As the issue will describe the feature good enough, team will be using the Git Squash command to hide the commits regarding the issue.

## Unity
This will cover how team will collaborate with Unity

### <ins>Variable scope
As the project will only be a public singleplayer game we won't give much focus on security. 

Team will be using public scope for global variables changed in the Inspector or by other classes, and private for the rest.

### <ins>Naming conventions
- **camelCase** for variables and public constants
- **PascalCase** for methods and script names/classes
- **SCREAMING_SNAKE_CASE** for private constants
- **Pascal Case With Spaces** for all objects and folders inside unity

## Logs
Team will be writing logs every week to say what they did in [logs.md](logs.md).

Every friday they will meet up either face to face or online and discuss what they did that week, afterwards they will write in the document and push to main directly.