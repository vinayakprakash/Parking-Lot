// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ParkingLot.Domain.Tests.Calculator
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ParkingChargesComputation")]
    public partial class ParkingChargesComputationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ParkingChargesComputation.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ParkingChargesComputation", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 2
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "PricingType",
                        "VehicleType",
                        "MinHour",
                        "MaxHour",
                        "Price"});
            table1.AddRow(new string[] {
                        "TwoWheeler1Hour",
                        "Hourly",
                        "2 Wheeler",
                        "0",
                        "1",
                        "30"});
            table1.AddRow(new string[] {
                        "TwoWheeler4Hour",
                        "4Hourly",
                        "2 Wheeler",
                        "1",
                        "4",
                        "100"});
            table1.AddRow(new string[] {
                        "TwoWheeler1Hour",
                        "24Hourly",
                        "2 Wheeler",
                        "4",
                        "24",
                        "200"});
            table1.AddRow(new string[] {
                        "TwoWheeler1Hour",
                        "Hourly",
                        "4 Wheeler",
                        "0",
                        "1",
                        "40"});
            table1.AddRow(new string[] {
                        "TwoWheeler1Hour",
                        "4Hourly",
                        "4 Wheeler",
                        "0",
                        "4",
                        "120"});
            table1.AddRow(new string[] {
                        "TwoWheeler1Hour",
                        "24Hourly",
                        "4 Wheeler",
                        "0",
                        "24",
                        "350"});
#line 3
testRunner.Given("Following pricing model for parkinglot1", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a vehicle leaves with the following details <below 1h>")]
        [NUnit.Framework.CategoryAttribute("1")]
        public virtual void WhenAVehicleLeavesWithTheFollowingDetailsBelow1H()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a vehicle leaves with the following details <below 1h>", null, new string[] {
                        "1"});
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 2
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "InTime",
                        "OutTime",
                        "VehicleType"});
            table2.AddRow(new string[] {
                        "2008-09-15T15:53:00",
                        "2008-09-15T16:45:00",
                        "4 Wheeler"});
#line 14
testRunner.Given("the details of vehicle and timing", ((string)(null)), table2, "Given ");
#line 17
testRunner.When("parking amount computation is launched", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Result"});
            table3.AddRow(new string[] {
                        "40"});
#line 18
testRunner.Then("following should be the price", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a vehicle leaves with the following details <1h>")]
        [NUnit.Framework.CategoryAttribute("2")]
        public virtual void WhenAVehicleLeavesWithTheFollowingDetails1H()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a vehicle leaves with the following details <1h>", null, new string[] {
                        "2"});
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 2
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "InTime",
                        "OutTime",
                        "VehicleType"});
            table4.AddRow(new string[] {
                        "2008-09-15T15:53:00",
                        "2008-09-15T16:53:00",
                        "2 Wheeler"});
#line 24
testRunner.Given("the details of vehicle and timing", ((string)(null)), table4, "Given ");
#line 27
testRunner.When("parking amount computation is launched", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Result"});
            table5.AddRow(new string[] {
                        "100"});
#line 28
testRunner.Then("following should be the price", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a vehicle leaves with the following details <more than 24h>")]
        public virtual void WhenAVehicleLeavesWithTheFollowingDetailsMoreThan24H()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a vehicle leaves with the following details <more than 24h>", null, ((string[])(null)));
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 2
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "InTime",
                        "OutTime",
                        "VehicleType"});
            table6.AddRow(new string[] {
                        "2008-09-15T15:53:00",
                        "2008-09-17T16:53:00",
                        "4 Wheeler"});
#line 33
testRunner.Given("the details of vehicle and timing", ((string)(null)), table6, "Given ");
#line 36
testRunner.When("parking amount computation is launched", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Result"});
            table7.AddRow(new string[] {
                        "1000"});
#line 37
testRunner.Then("following should be the price", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion