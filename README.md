# CodenameAura

Codename_Aura is the official Pre-Alpha source code of the old PaulModz Royale Server, I used this codename to differentiate other Versions of this source code.
I will not release the full source code, fixed and improved one unfortunately, that one is in Node JS, but I consider this one could do a great job for developers to use as a base.
An old Clash Royale Emulator/Server whatsoever, it is incomplete, don't dm me for anything, I will not help, yet, if you know how to use it, then make sure you are going to improve it, this is why I leave this project to the public. This is not the full source code, it is in alpha state.

I have no patched apk sorry. 

How to setup?
Add a rule in your firewall settings TCP - Port 9339
Change the ip in the source code with your server IP address
Build the solution
Start the executable from the bin/Debug.

(It is unstable, it wont support many connections, very good for testing out with friends on localhost usually.)

How to patch apk?
Download a Clash Royale apk file from google, open the libg.so with a HEX Editor, then find game.clashroyaleapp.com and replace with your own dns. (VERY IMPORTANT MAKE SURE IT'S A 23 CHARACTERS DNS) I recommend using: https://noip.com in creating your DNS.

If you use noip, how to setup a proper dns?
I assume you run the server on your computer or a server, these has a specific ip, when creating a DNS on noip there is an option to link the dns to your own IP so when the client connects to the DNS it redirects to your Server/Computer IP from where you run the server.

I left some comments in the code, they are in romanian so I am not so sure if it helps, but I am really sure someone with basic knowledge in how to setup servers can use this to run one. You can use this code as a foundation of future private server projects. Good luck!

![image](https://user-images.githubusercontent.com/49493490/111917405-7fd84f80-8a88-11eb-96ad-a1b540e626a2.png)
