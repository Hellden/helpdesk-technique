***EN***

**ASP.NET MVC**
Introduction Management of requests for interventions for the technical service of establishments. But can be adapted to other services needing a ticket manager with validation.

**Prerequisites**
IIS installation

If you have not installed IIS yet, I let you find a tutorial on an internet. Remember to add ASP.NET if the declaration in IIS is not done correctly.
Installing SQL Server and Configuration

- Download the compatible version for your Windows without GUI, for Windows Server 2008 R2 use the SQL Server 2014 version.
- Once installed, open a CMD console and type the following command: sqlcmd -S. \ SQLEXPRESS.
- You must create the user that is used in the application pool that is linked to your website. By default it is DefaultAppPool (if in doubt check in your IIS Binding Pool application). Create login [IIS APPPOOL \ DefaultAppPool] FROM WINDOWS press enter then GO key and enter again.
- Given the necessary rights on the SQL Server to the user creates: sp_addsrvrolemember '<Login>', 'sysadmin' call on entry then GO and again on entry.
WebDeploy Package Import-Import the newly created WebDeploy package via Visual Studio. For local connection strings, set: data source =. \ SQLEXPRESS; Integrated Security = SSPI; AttachDBFilename = | DataDirectory | aspnetdb.mdf; User Instance = true

This is normally if everything went well, your site will have to work normally.


***French***

**ASP.NET MVC** 

**Introduction**
Gestion des demandes d'interventions pour le **Service technique des établissements**. Mais peut être adapté à d'autres services ayant besoin d'un gestionnaire de ticket avec validation.

**Pré-requis**
Installation IIS
- Si vous n'avez pas encore installée IIS, je vous laisse trouver un tuto sur un internet.Pensez à rajouter ASP.NET si la déclaration dans IIS ne se fait pas correctement.


Installation de SQL Server et Configuration
- Télécharger la version compatible pour votre **Windows sans GUI**, pour Windows Serveur 2008 R2 utilisez la version [SQL Server 2014](https://www.microsoft.com/fr-FR/download/details.aspx?id=42299).
- Une fois installé, ouvrez une console **CMD** et tapez la commande suivante :  ```sqlcmd -S .\SQLEXPRESS```.
- Il faut créer l'utilsateur qui est utilisé dans le pool d'application qui est lié à votre site Web. Par défaut c'est **DefaultAppPool** (dans le doute vérifier dans votre IIS la liaison Pool application). ```Create login [IIS APPPOOL\DefaultAppPool] FROM WINDOWS appuyer sur la touche entrée puis GO et de nouveau entrée```.
- Donnée les droits nécessaire sur le Serveur SQL à l'utisateur crée: ```sp_addsrvrolemember '<Login>', 'sysadmin'  appyer sur entrée puis GO et de nouveau sur entrée ```.


Importation du paquet WebDeploy
-Importez le paquet WebDeploy fraichement crée via Visual Studio. Pour la chaines de connexion local, mettre : ```data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true```


Voila normalement si tout c'est bien passé, votre site devrez fonctionner normalement.
