using NUnit.Framework;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;
using Moq;

public class ExtendedDatabaseTests
{
    private const string EpicFailMessage = "YOU FAIL AHAHAHAHAHAHAHA";

    private const string ArrayLengthException = "Array's capacity must be {0}!";
    private const string ArrayIsFullExcpetion = "Array is full!";
    private const string ArrayIsEmptyException = "Array is empty!";
    private const string PersonWithIdNonExistnatException = "Person with Id: {0} doesn't exist!";
    private const string PersonWithNullUsernameException = "Username of user with Id:{0} is null!";
    private const string UsernameException = "User with username: {0} is non existant!";
    private const string IdNegativeException = "Ids cannot be negative!";

    private const int DefaultArrayLength = 16;
    private const int WorkingPeopleArrayLength = 4;
    private const int ThrowsExceptionPeopleArrayLength = 20;

    private IPerson[] InitializeValues(int totalCount)
    {
        Random random = new Random();

        string args = "gosho,ivan,damqn,petur,georgi,asmat,vasil,dimitur,mitko,maria,kaloqn,aleksandra,sofiq," +
            "petranka,valeriq,albena,lidiq,juliqna,veselina,desislava,hristo,simeon";

        var people = new List<IPerson>();

        string[] names = args.Split(',');
        for (int counter = 0; counter < totalCount; counter++)
        {
            people.Add(new Person(counter + 1, names[random.Next(0, names.Length)]));
        }

        return people.ToArray();
    }


    [Test]
    public void ValidateExtendedDbConstructor_True()
    {
        var type = typeof(ExtendedDatabase);
        var classInstance = new ExtendedDatabase();

        var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(IPerson[]));
        if (field == null)
        {
            Assert.Fail($"Field {typeof(IPerson[])} non existant!");
        }

        var people = (IPerson[])field.GetValue(classInstance);

        var expected = new IPerson[DefaultArrayLength];
        Assert.AreEqual(expected, people);
    }

    [Test]
    public void ParamsConstructor_SetInputParams()
    {
        var type = typeof(ExtendedDatabase);

        IPerson[] initialValues = this.InitializeValues(WorkingPeopleArrayLength);

        var dbInstance = new ExtendedDatabase(initialValues);

        var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(IPerson[]));

        if (field == null)
        {
            Assert.Fail($"Field {typeof(int[])} non existant!");
        }

        var fieldValues = (IPerson[])field.GetValue(dbInstance);

        IPerson[] expected = new IPerson[DefaultArrayLength];
        Array.Copy(initialValues, expected, initialValues.Length);

        Assert.That(fieldValues, Is.EqualTo(expected));
    }

    [Test]
    public void SetInputParams_ThrowException_True()
    {
        IPerson[] throwExcpetionPeopleValues = this.InitializeValues(ThrowsExceptionPeopleArrayLength);

        var type = typeof(ExtendedDatabase);
        var classInstance = new ExtendedDatabase();

        var testedMethod = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(IPerson[]))).FirstOrDefault();

        if (testedMethod == null)
        {
            Assert.Fail($"Private method of type {typeof(IPerson[])} doesnt exist!");
        }

        var exception = Assert
            .Throws<TargetInvocationException>(() => testedMethod.Invoke(classInstance, new object[] { throwExcpetionPeopleValues }));

        Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
        Assert.That(exception.InnerException.Message, Is.EqualTo(string.Format(ArrayLengthException, DefaultArrayLength)));
    }

    [Test]
    public void AddMethod_ThrowsExcpetion_True()
    {
        //Arrange
        IPerson[] initialPeople = this.InitializeValues(DefaultArrayLength);
        var type = typeof(ExtendedDatabase);
        var database = new ExtendedDatabase(initialPeople);

        var testedMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(IPerson)))
            .FirstOrDefault();

        if (testedMethod == null)
        {
            Assert.Fail($"Method of type: {typeof(void)} with {BindingFlags.Instance}, {BindingFlags.Public} does not exist!");
        }

        var fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(17);
        fakePerson.Setup(p => p.Username).Returns("Bai Ganio");

        //Act
        var excpetion = Assert
            .Throws<TargetInvocationException>(() => testedMethod.Invoke(database, new object[] { fakePerson.Object }));

        ;
        //Assert
        Assert.IsInstanceOf<InvalidOperationException>(excpetion.InnerException);
        Assert.That(excpetion.InnerException.Message, Is.EqualTo(ArrayIsFullExcpetion));
    }

    [Test]
    public void Remove_RemovesFromArray()
    {
        //Arrange
        IPerson[] initialPeople = this.InitializeValues(DefaultArrayLength);
        var type = typeof(ExtendedDatabase);
        var extendedDatabase = new ExtendedDatabase(initialPeople);

        var testedField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(IPerson[]));
        if (testedField == null)
        {
            Assert.Fail($"Field of type: {typeof(int[])} not set!");
        }

        //Act
        extendedDatabase.Remove();
        var fieldValues = (IPerson[])testedField.GetValue(extendedDatabase);

        var expected = new IPerson[DefaultArrayLength];
        Array.Copy(initialPeople, expected, initialPeople.Length - 1);

        //Assert
        Assert.AreEqual(expected, fieldValues);
    }

    [Test]
    public void Remove_ThrowsException_True()
    {
        //Arrange
        var type = typeof(ExtendedDatabase);
        var classInstance = new ExtendedDatabase();

        var testedMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .SingleOrDefault(m => m.ReturnType == typeof(void) && !m.GetParameters().Any());

        //Act
        var excpetion = Assert.Throws<TargetInvocationException>(() => testedMethod.Invoke(classInstance, new object[] { }));

        //Assert
        var expectedMessage = ArrayIsEmptyException;

        Assert.IsInstanceOf<InvalidOperationException>(excpetion.InnerException);
        Assert.That(excpetion.InnerException.Message, Is.EqualTo(expectedMessage));
    }

    [Test]
    public void Fetch_ReturnProperArrayLength_True()
    {

        var inputPeople = this.InitializeValues(WorkingPeopleArrayLength);

        var dbInstance = new ExtendedDatabase(inputPeople);

        var expected = new IPerson[inputPeople.Length];
        Array.Copy(inputPeople, expected, expected.Length);

        //Act
        var actual = dbInstance.Fetch();
        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SetValuesOfPerson_PersonConstructor()
    {
        //Arrange
        var type = typeof(Person);

        var classInstace = new Person(1L, "ivan");

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        
        //Act
        var fieldIdValue = (long)fields.Take(1).First().GetValue(classInstace);
        var fieldUsernameValue = (string)fields.Skip(1).First().GetValue(classInstace);

        var expectedId = 1L;
        var expectedName = "ivan";

        //Assert
        Assert.AreEqual(expectedId, fieldIdValue);
        Assert.AreEqual(expectedName, fieldUsernameValue);
    }

    [Test]
    public void ConstructorParams_ExtendedDatabaseConstructorShouldAddASingleOrMorePeopleToPeopleField()
    {
        var type = typeof(ExtendedDatabase);

        var fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(1);
        fakePerson.Setup(p => p.Username).Returns("ivan");

        var anotherPerson = new Mock<IPerson>();
        anotherPerson.Setup(p => p.Id).Returns(2);
        anotherPerson.Setup(p => p.Username).Returns("georgi");

        var classInstance = new ExtendedDatabase(fakePerson.Object, anotherPerson.Object);

        var testedField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .SingleOrDefault(f => f.FieldType == typeof(IPerson[]));

        if (testedField == null)
        {
            Assert.Fail(EpicFailMessage);
        }

        var fieldValue = testedField.GetValue(classInstance);

        var expected = new IPerson[DefaultArrayLength];
        expected.SetValue(fakePerson.Object, 0);
        expected.SetValue(anotherPerson.Object, 1);


        Assert.AreEqual(expected, fieldValue);
    }

    [Test]
    public void AddMethod_ShouldAddToPeople()
    {

        var type = typeof(ExtendedDatabase);

        var classInstance = Activator.CreateInstance(type, new object[] { });

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(void) && m.GetParameters().Any(p => p.ParameterType == typeof(IPerson)));
        if (method == null)
        {
            Assert.Fail(EpicFailMessage);
        }

        var fieldToTest = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .SingleOrDefault(f => f.FieldType == typeof(IPerson[]));

        if (fieldToTest == null)
        {
            Assert.Fail(EpicFailMessage);
        }

        Mock<IPerson> fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(1);
        fakePerson.Setup(p => p.Username).Returns("ivan");

        method.Invoke(classInstance, new object[] { fakePerson.Object });

        var fieldValue = fieldToTest.GetValue(classInstance);

        var expected = new IPerson[DefaultArrayLength];
        expected.SetValue(fakePerson.Object, 0);

        Assert.That(fieldValue, Is.EqualTo(expected));
    }

    [Test]
    public void AddMethodExtendedDatabase_ShouldThrowInvalidOperationExcpetionOnAddingAPersonWithSameId()
    {
        var initialPeople = this.InitializeValues(WorkingPeopleArrayLength);

        var type = typeof(ExtendedDatabase);

        var classInstance = Activator.CreateInstance(type, new object[] { initialPeople });

        var fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(4);

        var methodToTest = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(void) && m.GetParameters().Any(p => p.ParameterType == typeof(IPerson)));

        if (methodToTest == null) Assert.Fail();

        var exception = Assert.
            Throws<TargetInvocationException>(() => methodToTest.Invoke(classInstance, new object[] { fakePerson.Object }));

        string expected = $"User with Id: {fakePerson.Object.Id} already exists";

        Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
        Assert.AreEqual(expected, exception.InnerException.Message);
    }
    
    [Test]
    public void AddMethodExtendedDb_ThrowsExcpetionOnAddingAUserWithSameUsername()
    {
        var initialPeople = this.InitializeValues(WorkingPeopleArrayLength);

        var type = typeof(ExtendedDatabase);

        var classInstance = Activator.CreateInstance(type, new object[] { initialPeople });
        

        var methodToTest = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .SingleOrDefault(m => m.ReturnType == typeof(void) && m.GetParameters().Any(p => p.ParameterType == typeof(IPerson)));

        if (methodToTest == null) Assert.Fail(EpicFailMessage);

        Mock<IPerson> fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Username).Returns(initialPeople[WorkingPeopleArrayLength - 1].Username);
        fakePerson.Setup(p => p.Id).Returns(5);


        var exception =
            Assert.Throws<TargetInvocationException>(() => methodToTest.Invoke(classInstance, new object[] { fakePerson.Object }));

        string expected = $"User with Username: {fakePerson.Object.Username} already exists";

        Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
        Assert.AreEqual(expected, exception.InnerException.Message);
    }

    [Test]
    public void FindByUsername_ReturnsPerson()
    {
        IPerson expected = new Person(1, "ivan");

        var type = typeof(ExtendedDatabase);

        var classInstance = (ExtendedDatabase)Activator.CreateInstance(type, new object[] { expected });

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(string)));
        if (method == null)
        {
            Assert.Fail($"Method of return type: {typeof(IPerson)} and paramter type: {typeof(long)} is non existant!");
        }

        var actual = method.Invoke(classInstance, new object[] { expected.Username });

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FindByUsername_MakesADiffrenceBetweenCaseSensitiveUsers()
    {
        IPerson firstPerson = new Person(1, "ivan");
        IPerson secondPerson = new Person(2, "Ivan");

        var type = typeof(ExtendedDatabase);

        var classInstance = (ExtendedDatabase)Activator.CreateInstance(type, new object[] { firstPerson, secondPerson });

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(string)));
        if (method == null)
        {
            Assert.Fail($"Method of return type: {typeof(IPerson)} and paramter type: {typeof(long)} is non existant!");
        }

        var actual = method.Invoke(classInstance, new object[] { firstPerson.Username });

        var expected = new Person(secondPerson.Id, secondPerson.Username);
        Assert.AreNotSame(expected, actual);
    }

    [Test]
    public void FindByUsername_ThrowsInvalidOperationException()
    {
        var type = typeof(ExtendedDatabase);

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(string)));

        if (method == null)
        {
            Assert.Fail($"Method of return type: {typeof(IPerson)} and paramter type: {typeof(long)} is non existant!");
        }

        var classInstance = Activator.CreateInstance(type, new object[] { });

        string username = "pesho";

        var exception = Assert
            .Throws<TargetInvocationException>(() => method.Invoke(classInstance, new object[] { username }));

        string expected = string.Format(UsernameException, username);

        Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
        Assert.That(exception.InnerException.Message, Is.EqualTo(expected));
    }

    [Test]
    public void FindByUsername_ThrowsArgumentNullException()
    {
        var type = typeof(ExtendedDatabase);

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
           .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(string)));

        if (method == null)
        {
            Assert.Fail($"Method of return type: {typeof(IPerson)} and paramter type: {typeof(long)} is non existant!");
        }

        var fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(1);

        var classInstance = Activator.CreateInstance(type, new object[] { fakePerson.Object });

        var exception = Assert
            .Throws<TargetInvocationException>(() => method.Invoke(classInstance, new object[] { fakePerson.Object.Username }));

        var expected = string.Format(PersonWithNullUsernameException, fakePerson.Object.Id);

        Assert.IsInstanceOf<ArgumentNullException>(exception.InnerException);
        Assert.AreEqual(expected, exception.InnerException.Message);
    }

    [Test]
    public void FindById_ReturnsAUser_True()
    {
        //Arrange
        var person = new Person(1, "grozdanka");

        var type = typeof(ExtendedDatabase);

        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(long)));

        if (method == null)
        {
            Assert.Fail(EpicFailMessage);
        }

        var classInstance = Activator.CreateInstance(type, new object[] { person });

        //Act
        var actual = method.Invoke(classInstance, new object[] { person.Id });
        var expected = person;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FindById_ThrowsInvalidOperationException()
    {
        var type = typeof(ExtendedDatabase);

        var method = type.GetMethods()
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(long)));

        if (method == null)
        {
            Assert.Fail();
        }

        var classInstance = Activator.CreateInstance(type, new object[] { });

        var id = 4;
        var excpetion = Assert
            .Throws<TargetInvocationException>(() => method.Invoke(classInstance, new object[] { id }));

        string expected = string.Format(PersonWithIdNonExistnatException, id);

        Assert.IsInstanceOf<InvalidOperationException>(excpetion.InnerException);
        Assert.That(excpetion.InnerException.Message, Is.EqualTo(expected));
    }

    [Test]
    public void FindById_ThrowsArgumentOutOfRangeException()
    {
        var type = typeof(ExtendedDatabase);

        var method = type.GetMethods()
            .SingleOrDefault(m => m.ReturnType == typeof(IPerson) && m.GetParameters().Any(p => p.ParameterType == typeof(long)));

        if (method == null)
        {
            Assert.Fail();
        }

        Mock<IPerson> fakePerson = new Mock<IPerson>();
        fakePerson.Setup(p => p.Id).Returns(-1);
        fakePerson.Setup(p => p.Username).Returns("ivan");

        var classInstance = Activator.CreateInstance(type, new object[] { fakePerson.Object });


        var exception = Assert
            .Throws<TargetInvocationException>(() => method.Invoke(classInstance, new object[] { fakePerson.Object.Id }));

        var expectedMessage = IdNegativeException;

        Assert.IsInstanceOf<ArgumentOutOfRangeException>(exception.InnerException);
        Assert.AreEqual(exception.InnerException.Message, expectedMessage);
    }
}