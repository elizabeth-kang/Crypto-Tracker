function getPrice(fiatInput,cryptoInput) {
    // let fiatelem = document.getElementById('fiat');
    // let fiatInput = fiatelem.value;
    // let cryptoelem = document.getElementById('crypto');
    // let cryptotInput = cryptoelem.value;
    fetch('https://api.coinbase.com/v2/prices/'+ cryptoInput + '-'+ fiatInput +'/spot')
    .then((response) => response.json()).then((resBody) => {
        document.querySelector('#result-fiat').innerText = resBody.data.currency;
        document.querySelector('#result-crypt').innerText = resBody.data.base;
        document.querySelector('#result-amount').innerText = resBody.data.amount;
    });
}