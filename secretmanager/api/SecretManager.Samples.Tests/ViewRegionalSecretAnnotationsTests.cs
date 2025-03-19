/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.Cloud.SecretManager.V1;
using System;
using Xunit;


[Collection(nameof(RegionalSecretManagerFixture))]
public class ViewRegionalSecretAnnotationsTests
{
    private readonly RegionalSecretManagerFixture _fixture;
    private readonly ViewRegionalSecretAnnotationsSample _sample;

    public ViewRegionalSecretAnnotationsTests(RegionalSecretManagerFixture fixture)
    {
        _fixture = fixture;
        _sample = new ViewRegionalSecretAnnotationsSample();
    }

    [Fact]
    public void ViewRegionalSecretsAnnotations()
    {
        // Get the SecretName from the set ProjectId & LocationId.
        SecretName secretName = _fixture.Secret.SecretName;

        // Annotation Key-Value from the fixture class.
        string annotationKey = _fixture.AnnotationKey;
        string annotationValue = _fixture.AnnotationValue;

        // Run the code sample.
        Secret result = _sample.ViewRegionalSecretAnnotations(
          projectId: secretName.ProjectId, locationId: secretName.LocationId, secretId: secretName.SecretId);

        // Assert that the secretId is equal to the expected value.
        Assert.Equal(result.SecretName.SecretId, secretName.SecretId);

        // Assert that the annotation key's value matches with the expected value.
        Assert.Equal(result.Annotations[annotationKey], annotationValue);
    }
}
