# Source Code : Project

Add your source code for your Project in this folder.

# How To

- Navigate to 'C:\Windows\System32\drivers\etc'
    - Open hosts file
    - Add '127.0.0.1	wishingwebzbp'
    - Add '127.0.0.1	wishingwebzcrp'
    - Save (as Admin)

- Create a Sitecore 9.0.1 rev 171219 named 'schackwishingwebz03'

- Navigate to IIS
    - Select 'schackwishingwebz03'
    - Click Bindings
    - Add 'wishingwebzbp'
    - Add 'wishingwebzcrp'

- In Visual Studio, Publish Web 'schackwishingwebz03'
    - **Note: May need to get correct Microsoft.Practices.ServiceLocation.dll and paste in /bin**

- Login to Sitecore (http://schackwishingwebz03/sitecore/login)
    - Click Desktop
    - Click Content Editor
    - Click 'sitecore' Node
    - Navigate to Developer Tab in Ribbon
    - Click Update Tree
    - Publish Sitecore Items
        - /sitecore/content/bp
        - /sitecore/content/crp
        - /sitecore/layout/Layouts/wishingwebz
        - /sitecore/layout/Renderings/wishingwebz
        - /sitecore/media library/wishingwebz
        - /sitecore/templates/wishingwebz
        - /sitecore/templates/XConsent
    
- http://wishingwebzbp/ and http://wishingwebzcrp/ should work!
