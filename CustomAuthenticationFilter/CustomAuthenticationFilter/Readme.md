
##For Custom Authentication [MayankAuth]

- Add  <authentication mode="Forms"></authentication> in main web.config file in system.web tag
- Add a folder in main directory
- Add a class Named <yourAuthfile>.cs
- This class extends ActionFilterAttribute present in using System.Web.Mvc;
- This class implements IAuthenticationFilter - its two methods which are very important
- The Shared folder in View contain and Error view which was mentioned for fail case in the second implemented method.
- In the Route config the controller is Home and Action method is Index, which by default has no authentification, thus it redirects to error page.
- When we enter account/index in web url, we are redirected to login page
- when we enter username and password both as user (as we have hard coded it) then we are redirected to "Home" controller, "Index" Action. Like it should happen in case of successful login.

###<yourAuthFile>.cs 
This file is implementing two abstract methods OnAuthentication and OnAuthenticationChallenge. <br/>
The first method contains what should happen when authentication fails. Here we have to check the logic.<br/>
The second method contains where it should be redirected or what action should be taken in case of failure.