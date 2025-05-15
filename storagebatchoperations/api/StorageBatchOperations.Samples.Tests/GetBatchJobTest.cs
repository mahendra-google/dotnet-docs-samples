// Copyright 2025 Google LLC
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

using Google.Api.Gax.ResourceNames;
using System;
using Xunit;

[Collection(nameof(StorageFixture))]
public class GetBatchJobTest
{
    private readonly StorageFixture _fixture;

    public GetBatchJobTest(StorageFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetBatchJob()
    {
        GetBatchJobSample getJob = new GetBatchJobSample();
        var jobId = _fixture.GenerateJobId();
        var preGetJobName = $"{_fixture.Parent}/jobs/{jobId}";
        var postGetJobName = getJob.GetBatchJob(preGetJobName);
        Assert.NotNull(postGetJobName);
        Assert.Equal(preGetJobName, postGetJobName);
    }
}
