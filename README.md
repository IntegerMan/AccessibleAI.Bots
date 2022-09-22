# AccessibleAI Bots Project

The [AccessibleAI Bots Project](https://AccessibleAI.dev/bots) is a collection of *opinionated* utility projects designed to boost the speed of developing and prototyping new bots for those comfortable with .NET development.

This project is currently early in development and is expanding and iterating rapidly as it is used to build several bots. 

## Vision

The vision for the Accessible AI Bots Project is to provide a variety of capabilities that can be added to any bot developed using v4 of the Microsoft Bot Framework SDK.

The Accessible AI Bots Project is moderately opinionated in how classes and objects are structured in order to provide the best experience for people familiar with object-oriented programming in .NET but new to bot development.

The libraries are going to have the most immediate applicability for people building bots oriented around searching and presenting content and helping users find what they're looking for, simply because these are the types of bots it is being used to build right now.

## Packages

Presently there are five key pieces of the AccessibleAI Bots Project:

- [AccessibleAI.Bots.Core](https://github.com/IntegerMan/AccessibleAI.Bots/tree/main/AccessibleAI.Bots.Core) - contains common definitions and helpers. This contains the methods for easy card creation on responses.
- [AccessibleAI.Bots.Language.Azure](https://github.com/IntegerMan/AccessibleAI.Bots/tree/main/AccessibleAI.Bots.Language.Azure) - intent resolution from Azure using conversational language understanding (CLU) or orchestration workflows.
- [AccessibleAI.Bots.Language.Levenshtein](https://github.com/IntegerMan/AccessibleAI.Bots/tree/main/AccessibleAI.Bots.Language.Levenshtein) - Using [Levenshtein distance](https://en.wikipedia.org/wiki/Levenshtein_distance) to calculate the difference or similarities between strings to resolve intents from utterances without Azure.
- [AccessibleAI.Bots.Tables](https://github.com/IntegerMan/AccessibleAI.Bots/tree/main/AccessibleAI.Bots.Tables) - stores frequent responses to user queries in tabular form
- [AccessibleAI.Bots.Blobs](https://github.com/IntegerMan/AccessibleAI.Bots/tree/main/AccessibleAI.Bots.Blobs) - used to store easy-to-read transcripts for diagnostic purposes

All packages are available on NuGet as pre-release packages.

## Status

Right now this library is being radically expanded as new capabilities are added and more capabilities are pulled out of the base bot I created. I'm also trying to expand the documentation for what's there. Adapting this library is going to be a largely unstable experience at the moment with radical changes happening all the time, but by late 2022 it should be mature enough to be ready for public use.

**Note:** Expect massive amounts of change during this phase. Classes may be renamed, moved, deleted. Entire projects may be removed, renamed, or merged together. There may be bugs.

## Sponsoring

If you are interested in this project and want to help offset some of the hosting and experimentation costs incurred by the project, please consider [sponsoring this project](https://github.com/sponsors/IntegerMan).
