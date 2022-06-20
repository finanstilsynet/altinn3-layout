Models for working with altinn 3 layout files in C#

Design goals
===
* Safe, round trip serialization using System.Text.Json [Annotations], so that you don't need to specify JsonOptions
* Polymorphic components (Each component type has its own class, to get correct object from )
* Implement server side evaluation of dynamics
