# NeuroTune - AI-Enhanced Aim Trainer

## Contributors

<table>
  <tr>
    <td>
      <a href="https://github.com/thehansong">
        <img src="https://github.com/thehansong.png?size=75" alt="Hans ONG" style="border-radius: 50%; width: 50px; height: 50px;"/>
      </a>
    </td>
    <td style="vertical-align: middle; padding-right: 20px;">
      <a href="https://github.com/thehansong">Hans ONG</a> - AI & Gameplay Developer
    </td>
    <td>
      <a href="https://github.com/Markkeroni">
        <img src="https://github.com/Markkeroni.png?size=75" alt="Mark LOW" style="border-radius: 50%; width: 50px; height: 50px;"/>
      </a>
    </td>
    <td style="vertical-align: middle;">
      <a href="https://github.com/Markkeroni">Mark LOW</a> - AI & Gameplay Developer
    </td>
  </tr>
</table>


## Training your aim, one adaptive target at a time  
**NeuroTune** is an AI-driven aim trainer that adapts in real-time to improve your FPS skills by dynamically adjusting the size, spawn location, and lifetime of targets based on your performance.

![Gameplay Screenshot](https://i.imgur.com/xdKiV4v.png)

## Inspiration  
As competitive gaming and eSports gain momentum, we recognized a gap in personalized training tools. Traditional aim trainers like **Aim Lab** and **Kovaak's** offer great scenarios, but they lack real-time adaptability and personalization. NeuroTune was developed to address these limitations by creating an adaptive, AI-enhanced system that continuously challenges the user based on their current skill level, making training more efficient and engaging.

## What it does  
- **Adaptive Training**: Real-time adjustments of target size, spawn location, and lifetime based on player performance.
- **Fitts' Law Integration**: Uses Fitts' Law to create a training environment that adjusts difficulty dynamically.
- **Customizable Scenarios**: to add @mark
- **Performance Tracking**: Tracks hits, misses, and reaction times to optimize future training sessions.

## How we built it  
- **App/Trainer**: Built using **Unity** for 3D environments and **Python** for the AI-driven components.  
- **AI Integration**: Machine learning algorithms analyze player performance to adjust difficulty in real-time.  
- **Fitts' Law**: Implemented as the core mechanic to control target behavior based on distance, size, and player response time.

## Challenges we ran into  
We faced difficulties integrating Fitts' Law into a real-time system, as calculating dynamic target parameters while ensuring smooth gameplay required careful balancing. Additionally, creating an adaptive system that doesn't frustrate users while remaining challenging proved to be a balancing act.

## Accomplishments that we're proud of  
We successfully implemented real-time adaptability that provides meaningful and tailored training sessions. We also received positive feedback from initial testers, who saw significant improvement in their aiming accuracy after just a week of using NeuroTune.

## What we learned  
We learned the value of combining machine learning with game mechanics to create more personalized experiences. Additionally, we gained deeper insights into how principles like Fitts' Law can be applied to enhance user interaction in a game environment.

## What's next for NeuroTune  
We plan to refine the machine learning algorithms to provide even more precise adaptability based on user performance. We're also looking into expanding the system to support more advanced training scenarios, such as moving targets and multi-target environments.

## Fun Fact  
During our final testing phase, one of our testers experienced such a drastic improvement in their aim that they managed to hit a record Kills Per Minute (KPM) in **Counter-Strike 2** after just one week of training with NeuroTune!
