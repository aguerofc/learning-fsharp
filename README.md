# learning-fsharp
F# learning project

# Data Analyzer

## Overview

The Data Analyzer is a tool built to analyze CSV files and generate summary statistics or visualizations. It leverages F# and various libraries to provide insights into your data. This tool supports:

- Reading CSV files using F# Data type provider
- Calculating summary statistics like mean, median, and standard deviation
- Visualizing data using OxyPlot
- Exporting visualizations as image files

## Features

- **CSV Data Loading**: Uses F# Data type provider to easily load and access CSV data.
- **Statistical Analysis**: Calculates average, median, and standard deviation of specified columns.
- **Data Visualization**: Generates line plots of data columns and exports them as PNG files.

## Key Features and Skills

### 1. **F# Programming Language Basics**
   - Learn the fundamentals of F# syntax and functional programming paradigms.
   - Understand how to define and use functions, handle data types, and manage sequences.

### 2. **CSV Data Handling**
   - Utilize the F# Data type provider to read and parse CSV files.
   - Learn how to work with data rows and columns effectively.

### 3. **Data Processing and Transformation**
   - Process and transform data using functional programming techniques.
   - Apply functions to sequences for data manipulation (e.g., `Seq.map`, `Seq.choose`).

### 4. **Statistical Analysis**
   - Calculate statistical measures such as mean, median, and standard deviation using MathNet.Numerics.
   - Understand how to use statistical functions and interpret their results.

### 5. **Data Visualization**
   - Integrate with OxyPlot to create visual representations of data.
   - Learn to configure and customize plots, including setting titles and labels.

### 6. **File I/O Operations**
   - Work with file streams to save data visualizations as image files (e.g., PNG format).
   - Understand file handling and resource management in F#.

### 7. **Error Handling and Data Validation**
   - Implement error handling to deal with missing or invalid data.
   - Validate and clean data before processing and analysis.

### 9. **Integration of Multiple Libraries**
   - Learn to integrate and use multiple libraries within an F# project (e.g., FSharp.Data, MathNet.Numerics, OxyPlot).
   - Understand how to manage dependencies and leverage third-party tools.

### 10. **Project Setup and Configuration**
    - Set up and configure an F# project in Visual Studio.
    - Manage NuGet packages and project references.

## Setup

### Prerequisites

Ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [F# Data](https://github.com/fsharp/FSharp.Data) library
- [MathNet.Numerics](https://numerics.mathdotnet.com/) library
- [OxyPlot](https://oxyplot.github.io/) library for plotting

### Installation

#### Create a New F# Project in Visual Studio

1. **Open Visual Studio**:
   - Launch Visual Studio.

2. **Create a New Project**:
   - Go to **File** > **New** > **Project**.

3. **Select Project Template**:
   - In the "Create a new project" dialog, select **F#** from the language dropdown.
   - Choose **Console App (.NET Core)** or **Console App (.NET 8)** from the project templates.
   - Click **Next**.

4. **Configure Your Project**:
   - Enter a name for your project (e.g., `FirstLookToFSharp`).
   - Choose a location for your project files.
   - Click **Create**.

5. **Add Required Packages**:
   - Open the **NuGet Package Manager**:
     - Right-click on the project in the **Solution Explorer**.
     - Select **Manage NuGet Packages**.

   - Search for and install the following packages:
     - `FSharp.Data`
     - `MathNet.Numerics`
     - `OxyPlot.WindowsForms`

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
   

