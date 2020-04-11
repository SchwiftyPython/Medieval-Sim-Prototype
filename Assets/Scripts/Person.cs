using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Person : ISubscriber
{
    private readonly bool _isPlayer;
    private bool _isDead;

    private Reputation _reputation;

    private int _numGoats;

    public Person BirthFather { get; set; }
    public Person BirthMother { get; set; }
    public List<Person> Guardians { get; set; }
    public List<Person> Children { get; set; }
    public List<Person> Siblings { get; set; }

    public Guid Id;

    public int Happiness { get; set; }
    public int Health { get; set; }
    public int Smarts { get; set; }
    public int Looks { get; set; }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Sex { get; }

    public Person()
    {

    }

    public void OnNotify(string eventName, object broadcaster, object parameter = null)
    {
        throw new System.NotImplementedException();
    }

    private string GenerateName(List<string> possibleNameFiles)
    {
        return NameStore.Instance.GenerateFullName(possibleNameFiles, Sex);
    }
}
