class ListBox {
    constructor(arr, textBox) {
        this.array = arr;
        this.textBox = textBox;
        this.textBox.setAttribute('multiple', true);
        this.reload();
    }

    reload() {
        this.textBox.innerHTML = '';
        for (var i = 0; i < this.array.length; i++) {
            this.textBox.innerHTML += '<option>' + this.array[i] + '</option>';
        }
    }
}

function func(arr1, arr2) {
    var textBox1 = document.createElement('select');
    var textBox2 = document.createElement('select');
    var buttonDiv = document.createElement('div');
    var button1 = document.createElement('button');
    var button2 = document.createElement('button');
    var button3 = document.createElement('button');
    var button4 = document.createElement('button');
    var mainDiv = document.createElement('div');
    var box1 = new ListBox(arr1, textBox1);
    var box2 = new ListBox(arr2, textBox2);

    button1.innerHTML = '>>';
    button2.innerHTML = '>';
    button3.innerHTML = '<';
    button4.innerHTML = '<<';

    button1.onclick = function () {
        if (box1.textBox.options.length == 0) {
            alert('Empty Box!');
        }
        else {
            while (box1.array.length > 0) {
                box2.array.push(box1.array[0]);
                box1.array.splice(0, 1);
            }
            box1.reload();
            box2.reload();
        }
    }
    button2.onclick = function () {
        if (box1.textBox.options.length == 0) {
            alert('Empty Box!');
        }
        else {
            var bufarr = [];
            for (var i = box1.textBox.options.length - 1; i >= 0; i--) {
                if (box1.textBox.options[i].selected) {
                    bufarr.unshift(box1.array[i]);
                    box1.array.splice(i, 1);
                }
            }
            box2.array = box2.array.concat(bufarr);
            box1.reload();
            box2.reload();
        }
    }
    button3.onclick = function () {
        if (box2.textBox.options.length == 0) {
            alert('Empty Box!');
        }
        else {
            var bufarr = [];
            for (var i = box2.textBox.options.length - 1; i >= 0; i--) {
                if (box2.textBox.options[i].selected) {
                    bufarr.unshift(box2.array[i]);
                    box2.array.splice(i, 1);
                }
            }
            box1.array = box1.array.concat(bufarr);
            box1.reload();
            box2.reload();
        }
    }
    button4.onclick = function () {
        if (box2.textBox.options.length == 0) {
            alert('Empty Box!');
        }
        else {
            while (box2.array.length > 0) {
                box1.array.push(box2.array[0]);
                box2.array.splice(0, 1);
            }
            box1.reload();
            box2.reload();
        }
    }

    buttonDiv.appendChild(button1);
    buttonDiv.appendChild(button2);
    buttonDiv.appendChild(button3);
    buttonDiv.appendChild(button4);

    mainDiv.appendChild(textBox1);
    mainDiv.appendChild(buttonDiv);
    mainDiv.appendChild(textBox2);

    return mainDiv;
}

function Main() {
    var arr1 = ['Option1', 'Option2', 'Option3'];
    var arr2 = ['Option4', 'Option5'];
    var arr3 = ['opt1'];
    var arr4 = ['opt2', 'opt3', 'opt4'];
    document.body.appendChild(func(arr1, arr2));
    document.body.appendChild(func(arr3, arr4));
}