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
