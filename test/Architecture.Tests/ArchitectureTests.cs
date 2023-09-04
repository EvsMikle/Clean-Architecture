﻿using FluentAssertions;
using static NetArchTest.Rules.Types;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string PresentationNamespace = "Presentation";
    private const string WebNamespace = "Web";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        //  Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            WebNamespace
        };

        // Act
        var testResult = InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        //  Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            DomainNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            WebNamespace
        };

        // Act
        var testResult = InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        //  Arrange
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            DomainNamespace,
            ApplicationNamespace,
            PresentationNamespace,
            WebNamespace
        };

        // Act
        var testResult = InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        //  Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            DomainNamespace,
            ApplicationNamespace,
            InfrastructureNamespace,
            WebNamespace
        };

        // Act
        var testResult = InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Handlers_Should_HaveDependencyOnDomain()
    {
        //  Arrange
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        // Act
        var testResult = InAssembly(assembly).That().HaveNameEndingWith("Handler").Should().HaveDependencyOn(DomainNamespace).GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Controllers_Should_HaveDependencyOnMediatR()
    {
        //  Arrange
        var assembly = typeof(Presentation.AssemblyReference).Assembly;

        // Act
        var testResult = InAssembly(assembly).That().HaveNameEndingWith("Controller").Should().HaveDependencyOn("MediatR").GetResult();

        // Assert
        _ = testResult.IsSuccessful.Should().BeTrue();
    }
}
