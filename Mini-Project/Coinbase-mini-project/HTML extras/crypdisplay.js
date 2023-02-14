function priceFetcher(){
    const reqArr = [
    'https://api.coinbase.com/v2/prices/BTC-USD/spot',
    'https://api.coinbase.com/v2/prices/ETH-USD/spot',
    'https://api.coinbase.com/v2/prices/USDT-USD/spot',
    'https://api.coinbase.com/v2/prices/USDC-USD/spot',
    'https://api.coinbase.com/v2/prices/ETH2-USD/spot',
    'https://api.coinbase.com/v2/prices/DOGE-USD/spot',
    'https://api.coinbase.com/v2/prices/BUSD-USD/spot',
    'https://api.coinbase.com/v2/prices/ADA-USD/spot',
    'https://api.coinbase.com/v2/prices/SOL-USD/spot',
    'https://api.coinbase.com/v2/prices/DOT-USD/spot'
    ]
    Promise.all(reqArr.map((url) => fetch(url).then((response) => response.json()))).then((resBody) => {
        console.log(resBody);
        resBody.forEach(displayupdater);
    })
}
function displayupdater(data){
    const basestring = data.data.base;
    document.querySelector('#' + basestring).innerText = data.data.amount;
//    document.querySelector('#' + basestring + 'Currency').innerText = data.data.currency;
}

const loginArea = document.getElementById('loginArea'),
    submitBttn = document.getElementById('submit-bttn'),
    dashboard = document.getElementById('dashboard'),
    buy = document.getElementById('buy'),
    sell = document.getElementById('sell'),
    buyBttn = document.getElementById('buy-bttn'),
    sellBttn = document.getElementById('sell-bttn'),
    sellInput = document.getElementById('sell-input'),
    buyInput = document.getElementById('buy-input'),
    balanceDollar = document.getElementById('balance-dollar'),
    balanceETH = document.getElementById('balance-ETH'),
    balanceUSDT = document.getElementById('balance-USDT'),
    balanceETH2 = document.getElementById('balance-ETH2'),
    balanceUSDC = document.getElementById('balance-USDC'),
    balanceDOGE = document.getElementById('balance-DOGE'),
    balanceBUSD = document.getElementById('balance-BUSD'),
    balanceADA = document.getElementById('balance-ADA'),
    balanceSOL = document.getElementById('balance-SOL'),
    balanceDOT = document.getElementById('balance-DOT'),
    confirmBttn = document.getElementById('confirm-bttn');

    submitBttn.addEventListener('click', () => {
        loginArea.style.display ='none';
        dashboard.classList.remove('d-none');
    })

    sellBttn.addEventListener('click', () => {
        const value = sellInput.value;
        const SellValue = Number(sell.innerText) + Number(value);
        const DollarBalance = Number(balanceDollar.innerText) + Number(value);
        
        

    })









