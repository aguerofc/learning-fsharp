open System
open FSharp.Data
open MathNet.Numerics
open MathNet.Numerics.Statistics
open OxyPlot
open OxyPlot.Series
open OxyPlot.WindowsForms
open System.IO

// Define the CSV type provider
type CsvData = CsvProvider<"data.csv">

// Load the CSV file
let csv = CsvData.Load("data.csv")

// Print the header
printfn "Date       | Value"
printfn "------------------"

// Print the rows example of row
for row in csv.Rows do
    printfn "%s | %s" (row.Date.ToShortDateString()) (row.Value.ToString())

// Convert 'Value' column to float array
let values =
    csv.Rows
    |> Seq.map (fun row -> double row.Value)  // Convert to float
    |> Seq.toArray

// Calculate statistics
let average = Statistics.Mean(values)
let median = Statistics.Median(values)
let stdDev = Statistics.StandardDeviation(values)

printfn "Average: %f" average
printfn "Median: %f" median
printfn "Standard Deviation: %f" stdDev

// Function to analyze a specific column
let analyzeColumn (columnName: string) (rows: CsvData.Row seq) =
    let values =
        rows
        |> Seq.map (fun row ->
            match columnName with
            | "Value" -> 
                match System.Double.TryParse(row.Value.ToString()) with
                | (true, value) -> Some value
                | _ -> None
            | _ -> None  // Handle other columns if needed
        )
        |> Seq.choose id  //Remove None values
        |> Seq.toArray

    // Ensure values array is not empty to avoid errors
    if values.Length = 0 then
        (Double.NaN, Double.NaN, Double.NaN)  // Return NaN if no valid values
    else
        let average = Statistics.Mean(values)
        let median = Statistics.Median(values)
        let stdDev = Statistics.StandardDeviation(values)
        (average, median, stdDev)

// Function to plot data and save as an image file
let plotData (columnName: string) (rows: CsvData.Row seq) =
    let values =
        rows
        |> Seq.map (fun row ->
            match columnName with
            | "Value" -> 
                match System.Double.TryParse(row.Value.ToString()) with
                | (true, value) -> Some value
                | _ -> None
            | _ -> None  // Handle other columns if needed
        )
        |> Seq.choose id  //Remove None values
        |> Seq.toArray

    let plotModel = PlotModel()
    plotModel.Title <- sprintf "Plot of %s" columnName

    let series = LineSeries()
    series.Title <- columnName
    series.ItemsSource <- values |> Seq.mapi (fun i v -> DataPoint(float i, v)) |> Seq.toArray

    plotModel.Series.Add(series)
    
    // Save the plot as an image file
    let exporter = OxyPlot.WindowsForms.PngExporter()
    use stream = new FileStream(sprintf "%s_plot.png" columnName, FileMode.Create)
    exporter.Export(plotModel, stream)

    // Call the functions

// Analyze the 'Value' column
let columnName = "Value"  // Replace with actual column name if different
let (avg, med, sd) = analyzeColumn columnName csv.Rows

printfn "Column: %s" columnName
printfn "Average: %f" avg
printfn "Median: %f" med
printfn "Standard Deviation: %f" sd

// Plot the 'Value' column
plotData columnName csv.Rows

eprintf "End to basic learn"