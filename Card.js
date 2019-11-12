public class Card
{
  var cardNum;
  var securityCode;
  var expDate;

  constructor(cardNum, securityCode, expDate)
  {
    this.cardNum = cardNum;
    this.securityCode = securityCode;
    this.expDate = expDate;

    validateCard();
    encryptCard();
  }

  validateCard()
  {
    if (cardNum.toString().length != 16)
      // Throw error.

    if (securityCode.toString().length != 3)
      // Throw error.

    if (expDate == null)
      // Throw error.
  }

  encryptCard()
  {
    // Decide on encryption algorithm.
  }

  description()
  {
    // Decide on purpose of this function.
  }

  toString()
  {
    // Decide on relevant information.
  }
}
