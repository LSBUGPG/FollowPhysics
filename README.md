# Follow Physics

This project illustrates an issue with a camera following a Unity physics object.

Digital Foundry highlighted this issue in a recent video:

[![A link to the Digital Foundry video](DF.png)](https://youtube.com/watch?v=TQIBknDAj4g&t=3526)

To help show what's going on, this project contains two scenes. You should build and run these scenes rather than previewing them in the editor, as editor playback has its own frame pacing issues.

## Side By Side

The first scene shows a split screen with a ball rolling down a ramp. On the left, physics interpolation is off and the issue described is visible. On the right physics interpolation in on and the issue goes away.

![A screenshot from this scene](Comparison.png)

The graph at the bottom of each pane shows the acceleration of the camera object over time, where the camera is following the ball at a fixed distance and updating at approximately 60 frames per second.

In this scene, the ball has a `Rigidbody` component attached. On the left, the `Interpolate` parameter is set to `None` which is the default setting.

![A screenshot of the interpolation setting set to none](None.png)

On the right, the parameter is set to `Interpolate` which fixes the issue.

![A screenshot of the interpolation setting set turned on](Interpolate.png)

Press the `TAB` key to switch to the next scene.

## Toggle

In the next scene, you can toggle the interpolation setting on and off by pressing the `SPACE BAR` and move the ball around with the `W` `A` `S` `D` keys. Because this movement is applied using the physics system, it exhibits the same issue.

The best way to see the difference is to give the ball a small forward force by tapping the `W` key and then toggle with the `SPACE BAR`. If you look carefully at the floor, you should notice that the movement judders when interpolation is off and smooths out when it is on.