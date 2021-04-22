﻿﻿<h1 align="center">Media Metadata Dumper</h1><div align="center">

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/LegendaryB/media-metadata-dumper.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/media-metadata-dumper/blob/master/LICENSE)

<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

## What is this?
This tool runs through the files of a (media) folder and dumps metadata information related to them using ffprobe.

## Configuration
The `appsettings.json` file resides in the same folder as the application.
```json
{
    "directory": "",
    "filePattern": "*.*",
    "ffprobe": {
        "path": "",
        "command": "-print_format json -show_format -show_streams"
    },
    "Logging": {
        "Console": {
            "LogLevel": {
                "Default": "Information"
            }
        }
    }
}
```

|Property   |Description   |Default value   |
|---|---|---|
|directory   |The path to the files which should be analysed.   |none|
|filePattern   |A pattern used to retrieve the files which should be analysed.   |&ast;.&ast;|
|ffprobe.path   |The path were the ffprobe binary is located.   |none|
|ffprobe.command   |Command which should be run on a single file. Output is then saved to a file next to it.   |-print_format json -show_format -show_streams|

## Use the application
1. Download the application.
2. Extract it and navigate to the folder.
3. Configure your settings in the `appsettings.json` file.
4. Execute the application.

## Contributing

__Contributions are always welcome!__  
When you send me a pull request with changes, improvements or bugfixes please make sure to describe what did you do and why did you do it.

## License

This project is licensed under the MIT license - see the [LICENSE](LICENSE) file for details
