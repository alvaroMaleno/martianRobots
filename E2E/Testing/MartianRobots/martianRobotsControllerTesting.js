const http = require('http')
var assert = require('assert');

function getMartianStatsReturnsOK() {
    console.log('**********')
    console.log('Testing /api/MarsStats ReturnsOk')

    http.get('http://localhost:5000/api/MarsStats', res => {

        let rawData = ''

        res.on('data', chunk => {
            rawData += chunk
        })

        res.on('end', () => {

            assert(res.statusCode == 200, "Expected Status code = 200")
            console.log('Status = ' + res.statusCode)

            const parsedData = JSON.parse(rawData)

            assert(parsedData.totalOks > 0, "No totalOks")
            console.log("totalOks = " + parsedData.totalOks)
            assert(parsedData.totalLosts > 0, "No totalLosts")
            console.log("totalLosts = " + parsedData.totalLosts)
            assert(parsedData.totalEnvies > 0, "No totalEnvies")
            console.log("totalEnvies = " + parsedData.totalEnvies)
            assert(parsedData.oksPercentage > 0, "No oksPercentage")
            console.log("oksPercentage = " + parsedData.oksPercentage)
            assert(parsedData.totalCoordinates > 0, "No totalCoordinates")
            console.log("totalCoordinates = " + parsedData.totalCoordinates)
        })

    })
}

function getMarsCoordinatesVisitedReturnsOK() {
    console.log('**********')
    console.log('Testing /api/MarsCoordinatesVisited ReturnsOk')

    http.get('http://localhost:5000/api/MarsCoordinatesVisited', res => {

        let rawData = ''

        res.on('data', chunk => {
            rawData += chunk
        })

        res.on('end', () => {

            assert(res.statusCode == 200, "Expected Status code = 200")
            console.log('Status = ' + res.statusCode)

            const parsedData = JSON.parse(rawData)
            console.log(parsedData)
            console.assert(parsedData.length > 0, 'Empty return')
        })

    })
}

function getMartianRobotsInputsWithResultReturnsOK() {
    console.log('**********')
    console.log('Testing /api/MarsCoordinatesVisited ReturnsOk')

    http.get('http://localhost:5000/api/MartianRobotsInputsWithResult', res => {

        let rawData = ''

        res.on('data', chunk => {
            rawData += chunk
        })

        res.on('end', () => {

            assert(res.statusCode == 200, "Expected Status code = 200")
            console.log('Status = ' + res.statusCode)

            const parsedData = JSON.parse(rawData)
            console.log(parsedData)
            console.assert(parsedData.length > 0, 'Empty return')
        })

    })
}

function getMartianRobotsInputsReturnsOK() {
    console.log('**********')
    console.log('Testing /api/MarsCoordinatesVisited ReturnsOk')

    http.get('http://localhost:5000/api/MartianRobotsInputs', res => {

        let rawData = ''

        res.on('data', chunk => {
            rawData += chunk
        })

        res.on('end', () => {

            assert(res.statusCode == 200, "Expected Status code = 200")
            console.log('Status = ' + res.statusCode)

            const parsedData = JSON.parse(rawData)
            console.log(parsedData)
            assert(parsedData.length > 0, 'Empty return')
        })

    })
}


getMartianStatsReturnsOK();
setTimeout(getMarsCoordinatesVisitedReturnsOK, 100);
setTimeout(getMartianRobotsInputsWithResultReturnsOK, 150);
setTimeout(getMartianRobotsInputsReturnsOK, 200);

