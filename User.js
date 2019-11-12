public class User
{
  var firstName;
  var lastName;
  var userName;
  var password;
  var email;
  var phone;

  constructor(firstName, lastName, userName, password, email, phone)
  {
    this.firstName = firstName;
    this.lastName = lastName;
    this.userName = userName;
    this.password = password;
    this.email = email;
    this.phone = phone;

    validateUserData();
    encryptUserData();
  }

  validateUserData() {}

  encryptUserData()
  {
    // Decide on encryption algorithm.
  }

  deleteUser() {}

  login() {}

  logout() {}

  description()
  {
    // Decide on purpose of this function.
  }

  toString()
  {
    // Decide on relevant information.
  }
}
