
# Why?
Because I was looking for an mSecure -> lastPass converter but couldn't find one. So I built one myself.

# How?
Run the executable and provide two parameters *input file* and *outputfile*. You can also set the default filepath in the Constants.cs class.
You can also set up your mSecure categories there, as well as delimiters, but you probably don't need to change theses.
The resulting output is dependent on the category and can be adjusted in the Entry.cs class by modifiying the ToCSVString() method.

# Copyright & left?
[MIT licensed](LICENSE.md)