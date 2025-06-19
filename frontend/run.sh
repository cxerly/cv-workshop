#!/bin/sh
printenv >> log.txt

npm run build 

npm install -g serve@latest

serve -s dist -l 3000