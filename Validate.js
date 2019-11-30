var filesInDir = new Array();
//requiring path and fs modules
const path = require('path');
const fs = require('fs');
//joining path of directory 
const directoryPath = path.join(__dirname, 'lib/saves/users/basic');
//passsing directoryPath and callback function
fs.readdir(directoryPath, function (err, files) {
    if (err) {
        return console.log('Unable to scan directory: ' + err);
    }
    //listing all files
    files.forEach(function (file) {
        console.log(file);
        temp.push(file);
    });
    // This was used to test the array
    console.log(filesInDir);
});

var userInputUsername;
var userInputPassword;


for (let i = 0; i < filesInDir.length; i++) {
    if (userInput == filesInDir[i])
        if (userInputPassword == filesInDir[i].passord)
            return filesInDir[i];
    else return false;
}
