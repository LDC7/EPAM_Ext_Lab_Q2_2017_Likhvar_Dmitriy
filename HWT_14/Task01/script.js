function func(str) {
    var buf = str;
    console.log(buf);
    var sepArr = [' ', '\t', '?', '!', ':', ';', '.', ','];

    for (var i = 0; i < buf.length; i++) {
        if (sepArr.indexOf(buf[i]) != -1) {
            continue;
        }
        for (var j = i + 1; j < buf.length; j++) {
            if (sepArr.indexOf(buf[j]) != -1) {
                break;
            }
            if (buf[i] == buf[j]) {
                console.log(buf[i]);
                var buf2 = '';
                for (var k = 0; k < buf.length; k++) {
                    if (buf[k] != buf[i]) buf2 += buf[k];
                }
                buf = buf2;
                break;
            }
        }
    }

    console.log(buf);

    return buf;
}

function Main() {
    document.write("<pre>");
    document.writeln('abc');
    document.writeln(func('abc'));
    document.writeln('Абваабагнд');
    document.writeln(func('Абваабагнд'));
    document.writeln('У попа была собака');
    document.writeln(func('У попа была собака'));
    document.write("</pre>");
}

document.body.onload = Main();