using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTets
{
    public class DatabaseTests
    {
        private int[] arrayValues = new int[]  { 1, 4, 3, 5, 6, 7, 2, 4, 4, 3 };
        private int[] throwMethodExpcetionArray = new int[] { 16, 72, 73, 59, 58, 69, 52, 7, 97, 99, 84, 54, 92, 27, 52, 33 };
        private int[] throwExcpetionArrayValues = new int[] { 1, 1, 1, 1, 1, 2, 3, 4, 5, 2, 4, 6, 11, 2, 4, 6, 7, 8, 6, 45, 3, 2, 3, 5, 6, 7, 8, 9, 67, 5, 4, 3, 2, 1 };
        private const int DefaultArrayLength = 16;

        [Test]
        public void ValidateInitialConstructor_True()
        {
            var type = typeof(Database);
            var classInstance = new Database();
            
            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(int[]));
            if (field == null)
            {
                Assert.Fail($"Field {typeof(int[])} non existant!");
            }

            var numbers = (int[])field.GetValue(classInstance);

            var expected = new int[DefaultArrayLength];
            Assert.AreEqual(expected, numbers);
        }

        [Test]
        public void ParamsConstructor_SetInputParams()
        {
            var type = typeof(Database);

            var dbInstance = new Database(this.arrayValues);

            var field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(int[]));
            if (field == null)
            {
                Assert.Fail($"Field {typeof(int[])} non existant!");
            }

            var fieldValues = (int[])field.GetValue(dbInstance);

            int[] expected = new int[DefaultArrayLength];
            Array.Copy(this.arrayValues, expected, this.arrayValues.Length);

            Assert.That(fieldValues, Is.EquivalentTo(expected));
        }

        [Test]
        public void SetInputParams_ThrowException_True()
        {
            var type = typeof(Database);
            var classInstance = new Database();

            Assert.That(() => new Database(this.throwExcpetionArrayValues), Throws.InvalidOperationException.With
               .Message.EqualTo("Array's capacity must be 16!"));

            //var exception = Assert
            //    .Throws<TargetInvocationException>(() => testedMethod.Invoke(classInstance, new object[] { this.throwExcpetionArrayValues }));

            //Assert.IsInstanceOf<InvalidOperationException>(exception.InnerException);
            //Assert.That(exception.InnerException.Message, Is.EqualTo($"Array's capacity must be 16!"));
        }

        [Test]
        public void AddMethod_AddingElement()
        {
            //Arrange
            var type = typeof(Database);

            var dbInstance = new Database();

            var fieldToTest = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(int[]));
            if (fieldToTest == null)
            {
                Assert.Fail($"Field {typeof(int[])} not set!");
            }

            //Act
            dbInstance.Add(DefaultArrayLength);
            var fieldValue = (int[])fieldToTest.GetValue(dbInstance);

            //Assert
            Assert.That(fieldValue[0], Is.EqualTo(DefaultArrayLength));
        }

        [Test]
        public void AddMethod_ThrowsExcpetion_True()
        {
            //Arrange
            var type = typeof(Database);
            var database = new Database(this.throwMethodExpcetionArray);

            var testedMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(int)))
                .FirstOrDefault();

            if (testedMethod == null)
            {
                Assert.Fail($"Method of type: {typeof(void)} with {BindingFlags.Instance}, {BindingFlags.Public} does not exist!");
            }

            //Act
            var excpetion = Assert
                .Throws<TargetInvocationException>(() => testedMethod.Invoke(database, new object[] { DefaultArrayLength }));

            ;
            //Assert
            Assert.IsInstanceOf<InvalidOperationException>(excpetion.InnerException);
            Assert.That(excpetion.InnerException.Message, Is.EqualTo("Array is full!"));
        }

        [Test]
        public void Remove_RemovesFromArray()
        {
            var type = typeof(Database);
            var database = new Database(this.throwMethodExpcetionArray);

            var testedField = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).SingleOrDefault(f => f.FieldType == typeof(int[]));

            if (testedField == null)
            {
                Assert.Fail($"Field of type: {typeof(int[])} not set!");
            }

            database.Remove();

            var fieldValues = (int[])testedField.GetValue(database);

            var expected = new int[DefaultArrayLength];
            Array.Copy(this.throwMethodExpcetionArray, expected, this.throwMethodExpcetionArray.Length - 1);

            Assert.AreEqual(expected, fieldValues);
        }

        [Test]
        public void Remove_ThrowsException_True()
        {
            //Arrange
            var type = typeof(Database);
            var classInstance = new Database();

            var testedMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .SingleOrDefault(m => m.ReturnType == typeof(void) && !m.GetParameters().Any());

            //Act
            var excpetion = Assert.Throws<TargetInvocationException>(() => testedMethod.Invoke(classInstance, new object[] { }));

            //Assert
            var expectedMessage = $"Array is empty!";
            Assert.IsInstanceOf<InvalidOperationException>(excpetion.InnerException);
            Assert.That(excpetion.InnerException.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Fetch_ReturnProperArrayLength_True()
        {
            var dbInstance = new Database(this.arrayValues);

            var expected = new int[this.arrayValues.Length];
            Array.Copy(this.arrayValues, expected, expected.Length);


            var actual = dbInstance.Fetch();

            Assert.AreEqual(expected, actual);
        }
    }
}
