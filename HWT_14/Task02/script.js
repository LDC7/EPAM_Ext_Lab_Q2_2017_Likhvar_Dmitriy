function func(str) {
    var buf = str;    
    var numArr = [];
    var charArr = [];

    buf = buf.replace(/\s+/g, '');
    console.log(buf);

    var buf1 = '';
    for (var i = 0; i < buf.length; i++) {
        if (buf[i].match(/[\+\-*\/=]/)) {
            numArr.push(parseFloat(buf1));
            buf1 = '';
            if (buf[i] != '=') charArr.push(buf[i]);
        }
        else {
            buf1 += buf[i];
        }
    }

    console.log(numArr);
    console.log(charArr);

    //умножение и деление
    for (var i = 0; i < charArr.length; i++) {
        if (charArr[i] == '*') {
            console.log(numArr[i] + '*' + numArr[i + 1]);
            numArr[i] = numArr[i] * numArr[i + 1];
            console.log(numArr[i]);
            numArr.splice(i + 1, 1);
            charArr.splice(i, 1);
            i--;
        }
        if (charArr[i] == '/') {
            console.log(numArr[i] + '/' + numArr[i + 1]);
            numArr[i] = numArr[i] / numArr[i + 1];
            console.log(numArr[i]);
            numArr.splice(i + 1, 1);
            charArr.splice(i, 1);
            i--;
        }
    }
    //сложение и вычитание
    for (var i = 0; i < charArr.length; i++) {
        if (charArr[i] == '+') {
            console.log(numArr[i] + '+' + numArr[i + 1]);
            numArr[i] = numArr[i] + numArr[i + 1];
            console.log(numArr[i]);
            numArr.splice(i + 1, 1);
            charArr.splice(i, 1);
            i--;
        }
        if (charArr[i] == '-') {
            console.log(numArr[i] + '-' + numArr[i + 1]);
            numArr[i] = numArr[i] - numArr[i + 1];
            console.log(numArr[i]);
            numArr.splice(i + 1, 1);
            charArr.splice(i, 1);
            i--;
        }
    }

    return numArr[0];
}

function Main() {
    document.write("<pre>");
    document.writeln('3.5 +4*10-5.3 /5 =');
    document.writeln(func('3.5 +4*10-5.3 /5 ='));
    document.write("</pre>");
}

document.body.onload = Main();