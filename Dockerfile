# Use official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Install Chrome & ChromeDriver
RUN apt-get update && apt-get install -y wget gnupg unzip curl     && wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add -     && sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list'     && apt-get update && apt-get install -y google-chrome-stable     && CHROME_DRIVER_VERSION=$(curl -sS chromedriver.storage.googleapis.com/LATEST_RELEASE)     && wget -O /tmp/chromedriver.zip http://chromedriver.storage.googleapis.com/$CHROME_DRIVER_VERSION/chromedriver_linux64.zip     && unzip /tmp/chromedriver.zip -d /usr/local/bin/     && chmod +x /usr/local/bin/chromedriver

# Set working directory
WORKDIR /app

# Copy everything
COPY . .

# Restore and run tests
RUN dotnet restore
CMD ["dotnet", "test"]
