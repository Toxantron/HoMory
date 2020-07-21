# HoMory - HomeAutomation on MORYX

This a small text project to build a HomeAutomation system based on the [MORYX-AbstractionLayer](https://github.com/PHOENIXCONTACT/MORYX-AbstractionLayer). This is not intended to be a fully functional HomeAutomation system, but as an inspiration and best practice example for the possibilities of the MORYX Framework. It was initially the topic of my masters thesis and is now licensed under the GPLv3 license.

## Getting Started

Just open the solutions and run the application. Per default this will require access to port 80, alternative you can configure a different port in the **WcfConfig* within the *StartProject*. While the server is running you can open the *MaintenanceWeb* at http://localhost/maintenanceweb/. The *Dashboard* gives you an overview of the application, *Modules* is used to interact and configure modules, *Models* lets you create databases and schemas for installed data models, while *Log* grants live access to all logs.

The *ResourceManager* will fail upon start as it requires a database. First make sure you have [PostgreSQL installed](https://www.postgresql.org/download/), then start the application and open [Database configuration](http://localhost/maintenanceweb/#/databases). Configure the *Moryx.Resources.Model* and create the database. Afterwards restart the failed module, which should now be running with a notification because of the empty database.

The next step is to add an instance of *ResourceInteraction* to use the Resource UI for adding and configuring resources. The *ResourceManager* is pre-configured with an initializer, that creates the interaction endpoint. After the application started and the *ResourceManager* is running, enter the following commands into the console:

```sh
exec ResourceManager initialize 1
reinc ResourceManager
```

Once the module is running, start the front-end and you can create and configure building parts. You can also add additional resource types and drivers by installing their packages in the *StartProject*.

## Trouble Shooting

If you run into problems with the template or MORYX development in general, feel free to join our Gitter channel, ask on StackOverflow using the `moryx` tag or open an issue. In case your back-end application closes directly after start, this is mostly caused by lack of rights, reserved ports or missing libraries. MORYX creates crash log before exiting which can be find in the subdirectory *CrashLogs* in the *StartProjects* execution directory.
 
