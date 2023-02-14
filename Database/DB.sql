
CREATE TABLE Users (
	user_id INT IDENTITY,
	email NVARCHAR(100) UNIQUE NOT NULL,
	password NVARCHAR(100) NOT NULL,
	PRIMARY KEY (user_id)
);
--used during for the leaderboard and future plans-
CREATE TABLE Profiles (
	profile_id INT IDENTITY,
	user_id_fk INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
	first_name NVARCHAR(50) NOT NULL,
	last_name NVARCHAR(50) NOT NULL,
	PRIMARY KEY (profile_id)
);

CREATE TABLE Currency (
	currency_id INT IDENTITY,
    currency_symbol NVARCHAR(10) NOT NULL,
    currency_current_price DECIMAL(15,15) NOT NULL,
    currency_time DATETIME NOT NULL,
    PRIMARY KEY (Currency_id)
);

CREATE TABLE Wallets (
	wallet_id INT IDENTITY,
    user_id_fk INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
    currency_id_fk INT NOT NULL FOREIGN KEY REFERENCES Currency(currency_id),
    amount_currency DECIMAL(15,15) NOT NULL, --must be zero, neg, or pos-
    PRIMARY KEY (wallet_id)
);

--Still need the table for the bank/crypto setup before this table is ready to be added in db--
CREATE TABLE Transactions (
	transaction_id INT IDENTITY, 
    wallet_id_fk INT NOT NULL FOREIGN KEY REFERENCES Wallets(wallet_id),
    currency_id_fk INT NOT NULL FOREIGN KEY REFERENCES Currency(currency_id), 
    transaction_type NVARCHAR(4) NOT NULL CHECK (transaction_type IN ('Sell', 'Buy')),
    transaction_value DECIMAL(15,15) NOT NULL,
    transaction_time DATETIME NOT NULL DEFAULT (GETDATE()),
    PRIMARY KEY (transaction_id)
);


