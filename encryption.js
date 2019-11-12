var key = "ab";
var mod = 26;
// Where s is a string
function vignere(s) {
    var arr = [];
    var output = "";

    for (let i = 0; i < s.length; i++) {
        arr[i] = toChar(((letrDown(s[i]) +
            letrDown(key)) % mod) + ascii("a"));
        output = output.concat(arr[i]);
    }

    return output;
}

function decrypt(s) {

}

function ascii(a) {
    return a.charCodeAt(0);
}

function toChar(a) {
    return String.fromCharCode(a);
}

function letrDown(a) {
    var avar = ascii(a);
    var aa = ascii("a");
    var a_A = ascii("A");
    if ((avar - aa) < 26 && (avar - aa) >= 0)
        return avar - aa;

    if ((avar - a_A) < 26 && (avar - a_A) >= 0)
        return avar - a_A;

    return ascii(a);
}

console.log(vignere("hiya"));