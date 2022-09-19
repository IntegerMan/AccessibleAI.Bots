# AccessibleAI Bot Project

The [AccessibleAI Bot Project](https://AccessibleAI.dev/botproject) is a collection of *opinionated* utility projects designed to boost the speed of developing and prototyping new bots for those comfortable with .NET development.

This project is currently early in development and is expanding and iterating rapidly as it is used to build several bots. 

## Vision

The vision for the Accessible AI Bot Project is to provide a variety of capabilities that can be added to any bot developed using v4 of the Microsoft Bot Framework SDK.

However, the library's implementation is somewhat opinionated in how classes and objects are structured in order to provide the best experience for people familiar with object-oriented programming in .NET.

The libraries are going to have the most immediate applicability for people building bots oriented around searching and presenting content and helping users find what they're looking for, simply because these are the types of bots it is being used to build right now.

## Packages

Presently there are three key pieces of the AccessibleAI Bots Project:

- [AccessibleAI.Bots.LanguageUnderstanding](./AccessibleAI.Bots.LanguageUnderstanding/Readme.md) - makes it easier to call the new conversational language understanding and orchestration endpoints. Also includes helpers for ChitChat logic.
- [AccessibleAI.Bots.Tables](./AccessibleAI.Bots.Tables/Readme.md) - stores frequent responses to user queries in tabular form
- [AccessibleAI.Bots.Blobs](./AccessibleAI.Bots.Blobs/Readme.md) - used to store easy-to-read transcripts for diagnostic purposes

All packages will be made available both on GitHub and via NuGet, though packages may be marked as pre-release on NuGet for the time being.

## Status

Right now this library is being radically expanded as new capabilities are added and more capabilities are pulled out of the base bot I created. I'm also trying to expand the documentation for what's there. Adapting this library is going to be a largely unstable experience at the moment with radical changes happening all the time, but by late 2022 it should be mature enough to be ready for public use.

**Note:** Expect massive amounts of change during this phase. Classes may be renamed, moved, deleted. Entire projects may be removed, renamed, or merged together. There may be bugs.

## Sponsoring

If you are interested in this project and want to help offset some of the hosting and experimentation costs incurred by the project, please consider [sponsoring this project](https://github.com/sponsors/IntegerMan).