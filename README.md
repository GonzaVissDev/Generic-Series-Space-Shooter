# Unity Generic Series: Space Shooter.

Welcome to Generic Series: Space Shooter! This repository hosts the source code and assets of my space ship game project developed in Unity. In this game, players will embark on a thrilling space adventure, facing waves of enemies and collecting power-ups to enhance their abilities and tackle even greater challenges.

## Key Features

### Efficient Bullet Management with Pool Object

One of the main concerns while developing a game is resource efficiency. In this project, we've implemented a smart solution for bullet management using the "Pool Object" pattern. Instead of instantiating and destroying bullets each time they are fired, we've created a pool of pre-instantiated bullets that get recycled. This significantly improves performance by avoiding the overhead of constant creation and destruction, providing a smoother gameplay experience.

### Factory Pattern for Power-Up Creation
Power-ups are essential elements in our game as they provide players with temporary advantages that increase fun and strategy. To handle power-up creation, we've applied the Factory pattern. This allows us to dynamically create different types of power-ups, such as temporary shields, speed boosts, and more. Using this pattern makes our code scalable and easy to maintain, enabling us to add new power-ups without altering the core game flow.

### Enemy Wave Management with State Pattern

The gameplay in our game consists of various enemy waves, each with its own unique behavior and challenges. To achieve this, we've implemented the State pattern. Each state represents a different phase of the game, such as "Initial Wave," "Intense Wave," and "Final Boss." This enables us to easily control enemy behavior, difficulty, and wave frequency as players progress through the game.

## Installation and Usage Instructions
1. Clone this repository to your local machine using the command: `git clone https://github.com/your-username/your-repo.git`
2. Open Unity [2021.3.8f1].
3. In Unity, open the project and navigate to the `Assets` folder.
4. Explore the project structure, especially the `Scripts` folder, where you'll find scripts implementing the mentioned concepts.
5. From the Unity editor, enter Play mode to experience the game and test out the different mechanics.

## Contributions and Feedback

Contributions are welcome! If you'd like to contribute to the project, please follow these steps:

1. Fork this repository.
2. Create a new branch for your contribution: `git checkout -b my-new-feature`
3. Make your changes and improvements.
4. Submit a pull request describing your changes and why they should be merged.

## Credits and Acknowledgments

This project wouldn't have been possible without the support and resources provided by the Unity development community. We extend our gratitude to all the developers and creators whose online tutorials and guides inspired and guided us on this development journey.

---

Thank you for your interest in my Unity space shooter project! I hope you enjoy exploring the code and experimenting with the game. Feel free to get in touch if you have questions, suggestions, or simply want to share your impressions. Have fun playing and developing!
