# CurrencyExchange 

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)  [![forthebadge](https://forthebadge.com/images/badges/not-a-bug-a-feature.svg)](https://forthebadge.com)

CurrencyExchange is a simple currency converter that allow to convert from one currency to another, optimizing the best possible path to achieve the expected currency conversion 

Good to know : This project is  a technical test for the Lucca company ! 

## Develop with 

* [Serilog](https://serilog.net/) -  libraries for .NET, Serilog provides diagnostic logging the console.
* [An optimization of the Startup with StartupExtension](https://www.talkingdotnet.com/clean-way-to-add-startup-class-in-asp-net-core-6-project/) - To clean and organize properly the StartupFile
* [Recursion](https://devblogs.microsoft.com/oldnewthing/20180927-00/?p=99835) - Recursive version to find the best path
* [Dependancy Injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) - dependency injection software design pattern,for achieving Inversion of Control.


## Installation 

 

### Prerequisites

You need to have :
- a text file input to send in argument.
This file contains the currency exchange rates, and what you need to convert in this following format :

```txt
EUR;550;JPY
6
AUD;CHF;0.9661
JPY;KRW;13.1151
EUR;CHF;1.2053
AUD;JPY;86.0305
EUR;USD;1.2989
JPY;INR;0.6571
   ```

#### The first line contains:
- The initial currency in which the amount is displayed, as a code of 3
characters

-  The amount M in this original currency, as a positive integer > 0

- The target currency to convert, in the form of a code of 3
characters


#### The second line contains:
- An integer N indicating the number of exchange rates that will give you
be transmitted.

#### The following N lines contain:
- A representation the exchange rates



### Installation


Les étapes pour installer votre programme....

Dites ce qu'il faut faire...

_exemple_: Executez la commande ``telnet mapscii.me`` pour commencer ensuite [...]


Ensuite vous pouvez montrer ce que vous obtenez au final...





## Versions
Listez les versions ici
_exemple :_
**Dernière version stable :** 5.0
**Dernière version :** 5.1
Liste des versions : [Cliquer pour afficher](https://github.com/your/project-name/tags)
_(pour le lien mettez simplement l'URL de votre projets suivi de ``/tags``)_

## Auteurs
Listez le(s) auteur(s) du projet ici !
* **Jhon doe** _alias_ [@outout14](https://github.com/outout14)

Lisez la liste des [contributeurs](https://github.com/your/project/contributors) pour voir qui à aidé au projet !

_(pour le lien mettez simplement l'URL de votre projet suivi de ``/contirubors``)_

## License

Ce projet est sous licence ``exemple: WTFTPL`` - voir le fichier [LICENSE.md](LICENSE.md) pour plus d'informations








