// Copyright 2025 Andrei Rinea
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace CNP;

public enum ValidationError
{
    None = 0,
    ChecksumError = 1,
    InvalidSexDigit = 2,
    InvalidMonth = 4,
    InvalidDay = 8,
    InvalidDate = 16,
    InvalidCounty = 32,
    InvalidSequentialNumber = 64,
    InvalidDateForCounty = 128
}