﻿using FluentAssertions;
using static FunctionalStoryteller.Scenes;
using static FunctionalStoryteller.Specs;
using static FunctionalStoryteller.Storyteller;
using static FunctionalStoryteller.Tests.CharactersToTestsWith;

namespace FunctionalStoryteller.Tests;

public class DeathTests
{
    [Test]
    public void BuryAdan_DoesNotKillEva()
    {
        Death().Of(Adam).IsInTheTomb(Adam).Should().BeTrue();

        OnceUponATime()
            .Happened(Death().Of(Adam)).Then(Alive(Adam)).Should().BeFalse();

        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva)).Then(Alive(Eva)).Should().BeTrue();
    }
    
    [Test]
    public void CannotBeLoved_IfDead()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Adam).IsNone.Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeTrue();
    }

    [Test]
    public void TwoGhosts_FallInLove()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eva))
            .Happened(Love().Between(Adam, Eva))
            .WhoLoves(Eva).IsNone.Should().BeFalse();
    }

    [Test]
    public void AreInSameAstralPlane()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeFalse();
        
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Death().Of(Eva))
            .SharingAstralPlane(Adam, Eva).Should().BeTrue();
        
        OnceUponATime().SharingAstralPlane(Adam, Eva).Should().BeTrue();
    }

    [Test]
    public void KnowYouBecomeWidow_BreaksYourHeart()
    {
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .IsHeartbroken(Eva).Should().BeTrue();
        
        OnceUponATime()
            .Happened(Death().Of(Adam).WatchedBy(Eva))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she wasn't in love");
        
        OnceUponATime()
            .Happened(Love().Between(Adam, Eva))
            .Happened(Death().Of(Adam))
            .IsHeartbroken(Eva).Should().BeFalse(because: "she doesn't know");
    }

    [Test]
    public void CannotGrieve_Yourself()
    {
        Death().Of(Adam).PlaceAt(1, Adam).Should().Be(Death().Of(NobodyElse).WatchedBy(Adam));
    }
    
    [Test]
    public void ReviveSomeone()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Revive().Of(Adam))
            .Then(Alive(Adam)).Should().BeTrue();
    }
    
    [Test]
    public void ReviveSomeone_CanOnlyReviveDead()
    {
        OnceUponATime()
            .Happened(Revive().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Alive(Adam)).Should().BeFalse();
    }

    [Test]
    public void Die_Revive_Die()
    {
        OnceUponATime()
            .Happened(Death().Of(Adam))
            .Happened(Revive().Of(Adam))
            .Happened(Death().Of(Adam))
            .Then(Alive(Adam)).Should().BeFalse();
    }
}