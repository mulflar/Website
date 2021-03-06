﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MSPSpain.Tests
{
    [TestClass]
    public class Frontend
    {
        [TestMethod]
        public void MspJson()
        {
            JsonSchema schema = JsonSchema.Parse(@"{
                'type': 'array',
                'items': {
                    'type': 'object',
                    'properties': {
                        'id': {'type':'number'},
                        'msp': {'type':'boolean'},
                        'name': {'type':'string'},
                        'lastname': {'type':'string'},
                        'years': {'type':'array'},
                        'city': {'type':'string'},
                        'university': {'type':'string'},
                        'email': {'type':'string'},
                        'skills': {'type':'string'},
                        'twitter': {'type':'string'},
                        'linkedin': {'type':'string'},
                        'image': {'type':'string'},
                        'thumbnail': {'type':'string'},
                        'location': {'type':'object'}
                    }
                }
            }");

            string json = File.ReadAllText("../../../MSPSpain.Web/Content/FakeJSON/MspJSON.txt");
            JArray person = JArray.Parse(json);

            bool valid = person.IsValid(schema);
            Assert.IsTrue(valid);

        }
    }
}
