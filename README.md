# Egami Flow Screensaver
[![GitHub tag][GitHubTagImage]][GitHubTagUrl]
[![AppVeyor master][AppVeyorImage]][AppVeyorUrl]
[![license][LicenceImage]][LicenceUrl]

A configurable Windows screensaver allowing user specified images to float around the desktop with
composable behaviours and effects.

Multiple images may be specified and the screensaver will select from these images at random.

[<img src="./resources/EgamiFlowScreensaver.jpg" alt="Egami Flow Screensaver Screenshot" width="840px" style="width: 840px;"/>](./resources/EgamiFlowScreensaver.jpg?raw=true)

See the [configuration](#configuration) section for more details on the available features.

## Installation

Download *EgamiFlowScreensaver_Release_Any_CPU.zip* from the latest release found [here](https://github.com/natsnudasoft/EgamiFlowScreensaver/releases/latest).
Extract the contents of the zip file, and navigate to the *EgamiFlowScreensaver* folder and run
*Egami Flow Screensaver.exe* to install the screensaver. You should now be able to select the
screensaver from the Windows screensaver settings window.

[<img src="./resources/ScreensaverSettings.png" alt="Egami Flow Screensaver Screenshot" />](./resources/ScreensaverSettings.png?raw=true)

## Configuration

You can configure the screensaver by clicking the *Settings...* button on the Windows screensaver
settings window. The configuration window looks like the image below.

[<img src="./resources/EgamiFlowScreensaverConfiguration.png" alt="Egami Flow Screensaver Screenshot" />](./resources/EgamiFlowScreensaverConfiguration.png?raw=true)

On this page you can manage the images that will be randomly selected to float around the screen by
the screensaver while it is running, as well as configure a few other settings as follows:

### Contents
- [Images Settings](#images-settings)
    * [Add Image](#add-image)
    * [Remove Image](#remove-image)
    * [Image Emit Rate](#image-emit-rate)
    * [Max Image Emit Count](#max-image-emit-count)
    * [Image Emit Lifetime](#image-emit-lifetime)
    * [Infinite Emit Mode](#infinite-emit-mode)
    * [Image Emit Location](#image-emit-location)
- [Manage Emit Behaviours](#manage-emit-behaviours)
    * [Configure Behaviour](#configure-behaviour)
- [Background Settings](#background-settings)
    * [Desktop](#desktop)
    * [Solid Colour](#solid-colour)
    * [Image](#image)
        + [Image Position](#image-position)

### Images Settings
#### Add Image
Allows you to select a new image file to add to the list of images that will be randomly selected
when images are created.

#### Remove Image
Removes the selected image file from the list of images that will be randomly selected when images
are created.

#### Image Emit Rate
The number of new images that will be created by the screensaver per second.

#### Max Image Emit Count
The maximum number of images that will be created by the screensaver; when this number of images
are floating around the screen, the screensaver will stop creating new images.

#### Image Emit Lifetime
The time that emitted images will stay on the screen for (in milliseconds) if *Infinite Emit Mode*
is enabled. Behaviour transitions may extend this lifetime.

#### Infinite Emit Mode
Whether or not images will be emitted infinitely. In this mode, images will be destroyed after the
time set by *Image Emit Lifetime*, and may have transitioning effects while they are being destroyed
if any behaviours that allow this are enabled and configured to do so.

#### Image Emit Location
The location that images will be emitted at on the screensaver; possible values are described
in the following table:

| Value          | Description                                                                                                                             |
| -------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| Random Corner  | Images should be emitted from a random corner of the primary screen. The corner will be randomly chosen each time an image is emitted.  |
| Bottom Left    | Images should be emitted from the bottom left of the primary screen.                                                                    |
| Top Left       | Images should be emitted from the top left of the primary screen.                                                                       |
| Top Right      | Images should be emitted from the top right of the primary screen.                                                                      |
| Bottom Right   | Images should be emitted from the bottom right of the primary screen.                                                                   |
| Centre         | Images should be emitted from the centre of the primary screen.                                                                         |
| Random         | Images should be emitted from random locations on the primary screen.                                                                   |
| Custom...      | Images should be emitted from a selected location on the screensaver. This location can be selected with the *Choose Location* button.  |

#### Manage Emit Behaviours

Displays a window allowing you to manage various effects and behaviours that can be applied to any
images emitted by the screensaver. This window contains a list of available behaviours that you can
enable by ticking the relevant checkbox; a description of the selected behaviour is shown underneath
the list.

[<img src="./resources/EgamiFlowApplyBehaviorsConfiguration.png" alt="Egami Flow Apply Behaviours Configuration Screenshot" />](./resources/EgamiFlowApplyBehaviorsConfiguration.png?raw=true)

##### Configure Behaviour
Configure the selected behaviour in the behaviours list, if it has any configuration options; the
behaviour must be enabled before you are able to configure it.

### Background Settings
#### Desktop
The screensaver will take a screenshot of the current desktop and use that as the background.
<sub>*(This setting does not currently work on Windows 8 and up; preview mode works fine, however
when the screensaver actually runs, a grey background shows instead.)*</sub>

#### Solid Colour
The screensaver will display a chosen colour as the background. The colour to be displayed can be
selected by clicking the *Choose Colour* button.

#### Image
The screensaver will display a chosen image as the background. The image to be displayed can be
selected by clicking the *Choose Image* button. You may also specify the colour to be displayed
behind this image by clicking the *Choose Colour* button.

##### Image Position
How the screensaver will position the chosen background image; possible values are described
in the following table:

| Value   | Description                                                                                                                                                        |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Centre  | The image will remain centred at its original size.                                                                                                                |
| Fill    | The image will scale up or down to the minimum possible size required to fill the entire background, maintaining the images original aspect ratio.                 |
| Fit     | The image will scale up or down to the maximum possible size required to display the entire image on the background, maintaining the images original aspect ratio. |
| Stretch | The image will scale to the same size as the background area, ignoring the images original aspect ratio.                                                           |
| Tile    | The image will be repeated across the screen at its original size.                                                                                                 |

[GitHubTagImage]: https://img.shields.io/github/tag/natsnudasoft/EgamiFlowScreensaver.svg?maxAge=300&style=flat-square
[GitHubTagUrl]: https://github.com/natsnudasoft/EgamiFlowScreensaver
[AppVeyorImage]: https://img.shields.io/appveyor/ci/natsnudasoft/EgamiFlowScreensaver/master.svg?maxAge=300&style=flat-square
[AppVeyorUrl]:  https://ci.appveyor.com/project/natsnudasoft/EgamiFlowScreensaver/branch/master
[LicenceImage]: https://img.shields.io/github/license/natsnudasoft/EgamiFlowScreensaver.svg?maxAge=2592000&style=flat-square
[LicenceUrl]: http://www.apache.org/licenses/LICENSE-2.0