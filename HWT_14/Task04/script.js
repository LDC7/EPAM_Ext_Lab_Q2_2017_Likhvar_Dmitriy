function nextPage() {
    console.log('forward');
    var numPage = parseInt(fileName().substr(5, 1));
    console.log(numPage);
    if (numPage != 3 ) {
        console.log('back');
        numPage += 1;
        window.location.href = 'index' + numPage + '.html';
    }
    else {
        var loopFlag = confirm("Again?");
        if (loopFlag) {
            window.history.go(-2);
        }
        else {
            window.close();
        }
    }
}

function prevPage() {
    console.log('back');
    window.history.back();
}

function reloadTimer() {
    timer -= stopFlag * 10;
    time.innerText = (timer / 1000);
    if (timer == 0) {
        nextPage();
    }
}

function buttons() {
    var buttonBack = document.createElement('button');
    var buttonStart = document.createElement('button');
    var buttonStop = document.createElement('button');
    var buttonForward = document.createElement('button');

    buttonBack.innerText = '<<';
    buttonBack.onclick = prevPage;
    buttonStop.innerText = '||';
    buttonStop.onclick = function () {
        stopFlag = false;
        buttons();
    }
    buttonStart.innerText = '|>';
    buttonStart.onclick = function () {
        stopFlag = true;
        buttons();
    }
    buttonForward.innerText = '>>';
    buttonForward.onclick = nextPage;

    buttonDiv.innerText = '';
    if (fileName() == 'index1.html') {
        buttonBack.disabled = true;
    }
    buttonDiv.appendChild(buttonBack);
    if (stopFlag) {
        buttonDiv.appendChild(buttonStop);
    }
    else {
        buttonDiv.appendChild(buttonStart);
    }
    buttonDiv.appendChild(buttonForward);
}

var timer;
var time;
var buttonDiv;
var stopFlag;

function Main() {
    timer = 7000;
    time = document.createElement('p');
    buttonDiv = document.createElement('p');
    stopFlag = true;

    reloadTimer();
    var reTime = setInterval(reloadTimer, 10);
    buttons();
    
    document.body.appendChild(time);
    document.body.appendChild(buttonDiv);
}

function fileName() {
    return window.location.href.substring(window.location.href.lastIndexOf('/') + 1, window.location.href.length);
}