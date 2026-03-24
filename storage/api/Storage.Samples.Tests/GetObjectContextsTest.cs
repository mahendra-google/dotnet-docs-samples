// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License").
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at 
//
// https://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and 
// limitations under the License.

using Google.Apis.Storage.v1.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

[Collection(nameof(StorageFixture))]
public class GetObjectContextsTest
{
    private readonly StorageFixture _fixture;

    public GetObjectContextsTest(StorageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetObjectContexts()
    {
        GetObjectContextsSample contextsSample = new GetObjectContextsSample();

        string contextKey = "A\u00F1\u03A9\U0001F680";
        string contextValue = "Ab\u00F1\u03A9\U0001F680";

        var custom = new Dictionary<string, ObjectCustomContextPayload>
        {
            { contextKey, new ObjectCustomContextPayload { Value = contextValue } }
        };

        var destination = new Google.Apis.Storage.v1.Data.Object
        {
            Bucket = _fixture.BucketNameRegional,
            Name = Guid.NewGuid().ToString(),
            Contexts = new Google.Apis.Storage.v1.Data.Object.ContextsData { Custom = custom }
        };
        var content = Guid.NewGuid().ToString();
        byte[] byteArray = Encoding.UTF8.GetBytes(content);
        MemoryStream source = new MemoryStream(byteArray);
        var result = _fixture.Client.UploadObject(destination, source);
        var contextsData = contextsSample.GetObjectContexts(_fixture.BucketNameRegional, result.Name);
        Assert.Equal(destination.Contexts.Custom.Count, contextsData.Custom.Count);
        var resultEntry = Assert.Single(contextsData.Custom);
        Assert.Equal(contextKey, resultEntry.Key);
        Assert.Equal(contextValue, resultEntry.Value.Value);
    }
}
