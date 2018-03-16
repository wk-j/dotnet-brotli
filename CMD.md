## Commands

```
nuget config -set https://dotnet.myget.org/F/dotnet-corefxlab/api/v3/index.json  -configfile NuGet.config

mkdir resources/{inputs,brotli,gzip}

wget https://ajax.googleapis.com/ajax/libs/angularjs/1.5.6/angular.min.js --output-document resources/angular.min.js
wget https://cdnjs.cloudflare.com/ajax/libs/react/16.2.0/umd/react.production.min.js --output-document resources/react.production.min.js

for file in resources/inputs/*
    set rs (wk-file-size $file)
    echo "$file $rs"
end

for file in resources/brotli/*
    set rs (wk-file-size $file)
    echo "$file $rs"
end

for file in resources/gzip/*
    set rs (wk-file-size $file)
    echo "$file $rs"
end
```