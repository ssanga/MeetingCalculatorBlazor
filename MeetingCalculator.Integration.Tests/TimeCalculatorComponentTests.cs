using Bunit;
using MeetingCalculator.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace MeetingCalculator.Integration.Tests
{
    // https://github.com/egil/bUnit
    // https://bunit.egilhansen.com/docs/getting-started/writing-csharp-tests.html?tabs=xunit

    public class TimeCalculatorComponentTests : TestContext, IDisposable
    {
        private TestContext _ctx;

        public TimeCalculatorComponentTests()
        {
            _ctx = new TestContext();
            _ctx.Services.AddSingleton<ITimeCalculation>(new TimeCalculation());
        }

        public override void Dispose()
        {
            _ctx.Dispose();
        }

        [Fact]
        public void TimeCalculatorComponent_RendersCorrectly()
        {
            // Act
            var cut = _ctx.RenderComponent<TimeCalculator>();

            var renderedMarkup = cut.Markup;

            // Assert
            Assert.Contains("<h1>Meeting Calculator</h1>", renderedMarkup);
        }

        [Fact]
        public void TimeCalculatorComponent_RendersCorrectly_h1()
        {
            // Act
            var cut = _ctx.RenderComponent<TimeCalculator>();

            var smallElm = cut.Find("h1");

            // Assert
            smallElm.MarkupMatches("<h1>Meeting Calculator</h1>");
        }

        [Fact]
        public void TimeCalculatorComponent_ClickStartButtonShouldChangeTestButtonToStop()
        {
            // Act
            var cut = _ctx.RenderComponent<TimeCalculator>();

            cut.Find("button").Click();

            // Assert - find differences between first render and click
            var diffs = cut.GetChangesSinceFirstRender();

            // Only expect there to be one change
            var diff = diffs.ShouldHaveSingleChange();
            // and that change should be a text
            // change to "Stop"
            diff.ShouldBeTextChange("Stop");
        }
    }
}