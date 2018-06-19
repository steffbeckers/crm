@echo off
start powershell -noexit -command "mongod"
start powershell -noexit -command "cd loopback; npm start"
start powershell -noexit -command "cd vue; npm start"
code C:\dev\CRM
exit