# Porsche Explorer Project

Welcome to the Porsche Explorer Project!

Explore the world of Porsche with our WPF-based application, where you can discover, customize, and stay updated on your favorite Porsche models.

## Features

- **Model Exploration:** Browse through a wide range of Porsche models with detailed information.
- **Customization:** Tailor your experience by filtering models based on your preferences.
- **Interactive Pages:** Engage with our Contact and Subscribe pages for feedback and updates.
- **User Accounts:** Securely create and manage your profile to save personalized preferences.
- **Database Integration:** Utilizes a database to store user information and preferences.
- **Email Notifications:** Stay informed with email updates using the SMTP protocol.

## Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) installed
- [NuGet Package Manager](https://www.nuget.org/) for package dependencies
- [.NET](https://dotnet.microsoft.com/en-us/download) for .net framework

### Installation

### Installation

1. Clone the repository: `git clone https://github.com/Orkhaann/Porsche-.git`
2. Open the project in Visual Studio.
3. Update App Settings:
   - Navigate to the `appsettings.json` file in the project.
   - Modify the values in the section according to your smtp configuration.

     Example `appsettings.json`:
     ```json
     {
       "SmtpServer": "your.smtp.server.com",
       "SmtpPort": 587,
       "SmtpUsername": "your.email@gmail.com",
       "SmtpPassword": "yourSmtpPassword",
       "SenderEmail": "your.sender@gmail.com",
       "RecipientEmail": "your.recipient@gmail.com"
     }
     ```
4. Build and run the application in Visual Studio.

## Contributing

We welcome contributions! If you'd like to contribute, please fork the repository and create a pull request. Feel free to open issues for feature requests or bug reports.

## Contact

Have questions or feedback? Feel free to reach out to us via email at [orkhanm07@gmail.com](mailto:orkhanm07@gmail.com).

## License

This project is licensed under the [MIT License](LICENSE).

---

Happy exploring! 🏁
