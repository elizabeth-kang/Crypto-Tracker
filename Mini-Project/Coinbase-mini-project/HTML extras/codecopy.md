*{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family:'Times New Roman', Times, serif
}

html body{
    min-height: 100vh;
    background-image: url(images/cryptobackgrnd2.png);
    background-attachment: fixed;
    background-position: center;
    background-size: cover;
}
nav{
    width: 100%;
    padding: 10px 5px 0 5px 0;
    display: flex;
    align-items: center;
    background-color: rgb(16, 16, 131);
}
.logo{
    width: 50px;
    cursor: pointer;
    margin-left: 10px;
}
nav ul{
    flex: 1;
}
nav ul li{
    display: inline-block;
    margin: 5px 20px;
}
nav ul li a{
    color: #fff;
    text-decoration: none;
}
nav .btn{
    color: #fff;
    text-decoration: none;
    border: 2px solid #fff;
    padding: 10px 30px;
    border-radius: 30px;
    background-color: rgba(0, 0, 82, 0.402);
    margin-bottom: 5px;
}
.container{
    width: 100%;
    height: 100vh;
    padding: 0 7%;
    color: blue;
}
.content h1{
    font-size: 88px;
    margin-bottom: 15px;
    border: black;
    border-width: 1px;
    padding-top: 30px;
}
.content h1 span{
    color: rgb(0, 221, 255);
}
.container p{
    line-height: 22px;
    font-size: 24px;
}
.content .btn{
    display: inline-block;
    margin-top: 30px;
    background: rgb(16, 16, 131);
    color: #fff;
    text-decoration: none;
    padding: 15px 30px;
    border-radius: 30px;
}
.coin-list{
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
    grid-auto-rows: minmax(100px, auto);
    gap: 30%;
    position:relative;
    align-items: center;
    padding: 40px 40px 40px 40px;
}
.coin{
    display:inline-flex;
    align-items: center;
    font-size: 24px;
    margin: 0 15px;
    color: rgb(16, 16, 131);
    border: 1px solid blue;
    padding: 20px 30px;
    border-radius: 8px;
    background-color: rgba(9, 9, 255, 0.1);
}
.coin img{
    width:  150px;
    margin-right: 10px;
}
.coin h3{
    color: blue;
    margin-bottom: 5px;

}
.coin p{
    font-size: 32px;
}
.footer{
    position: absolute;
    bottom: 0;
}

..................................................above css 