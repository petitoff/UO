package com.example.demo.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;

@Entity
@DiscriminatorValue("spodnie")
public class Spodnie extends Ubranie{
    private Boolean czy_jeans;
    private String rodzaj_nogawki;
    private Integer ilosc_kieszeni;

    public Boolean getCzy_jeans() {
        return czy_jeans;
    }

    public void setCzy_jeans(Boolean czy_jeans) {
        this.czy_jeans = czy_jeans;
    }

    public String getRodzaj_nogawki() {
        return rodzaj_nogawki;
    }

    public void setRodzaj_nogawki(String rodzaj_nogawki) {
        this.rodzaj_nogawki = rodzaj_nogawki;
    }

    public Integer getIlosc_kieszeni() {
        return ilosc_kieszeni;
    }

    public void setIlosc_kieszeni(Integer ilosc_kieszeni) {
        this.ilosc_kieszeni = ilosc_kieszeni;
    }
}
