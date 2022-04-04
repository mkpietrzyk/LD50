using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class ActivatorController : MonoBehaviour
{
    public TextAsset countriesJSON;

    [System.Serializable]
    public class Country
    {
        public string name;
        public string code;
    }

    [System.Serializable]
    public class Countries
    {
        public Country[] countries;
    }

    public Countries myCountriesList = new Countries();
    public Country[] difficultCountries;
    public Country[] mediumCountries;
    public Country[] easyCountries;

    private void Start()
    {
        myCountriesList = JsonUtility.FromJson<Countries>(countriesJSON.text);
        difficultCountries = myCountriesList.countries.Where((country) => country.name.Length > 10).ToArray();
        mediumCountries = myCountriesList.countries
            .Where((country) => country.name.Length > 6 && country.name.Length <= 10).ToArray();
        easyCountries = myCountriesList.countries.Where((country) => country.name.Length <= 6).ToArray();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            var localScaleZ = other.transform.localScale.z;
            if (localScaleZ == 4)
            {
                var randomIndex = Random.Range(0, difficultCountries.Length);
                var selectedCountry = difficultCountries[randomIndex].name;
                other.GetComponentInChildren<TextMeshPro>().text = selectedCountry.ToLower();
            }
            else if (localScaleZ == 1 || localScaleZ == 2)
            {
                var randomIndex = Random.Range(0, mediumCountries.Length);
                var selectedCountry = mediumCountries[randomIndex].name;
                other.GetComponentInChildren<TextMeshPro>().text = selectedCountry.ToLower();
            }
            else
            {
                var randomIndex = Random.Range(0, easyCountries.Length);
                var selectedCountry = easyCountries[randomIndex].name;
                other.GetComponentInChildren<TextMeshPro>().text = selectedCountry.ToLower();
            }
        }
    }
}