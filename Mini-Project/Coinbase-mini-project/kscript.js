function getPrice(fiatInput,cryptoInput) {
    console.log(fiatInput);
    console.log(cryptoInput);
    fetch('https://api.coinbase.com/v2/prices/'+ cryptoInput + '-'+ fiatInput +'/spot')
    .then((response) => response.json()).then((resBody) => {
        document.querySelector('#result-fiat').innerText = resBody.data.currency;
        document.querySelector('#result-crypt').innerText = resBody.data.base;
        document.querySelector('#result-amount').innerText = resBody.data.amount;
    });
}