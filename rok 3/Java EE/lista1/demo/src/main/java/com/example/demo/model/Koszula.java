package com.example.demo.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;

@Entity
@DiscriminatorValue("koszula")
public class Koszula extends Ubranie {
    private Boolean czy_guziki;
    private Boolean czy_dlugi_rekaw;
    private String rodzaj_kolnierzyka;

    public Boolean getCzy_guziki() {
        return czy_guziki;
    }

    public void setCzy_guziki(Boolean czy_guziki) {
        this.czy_guziki = czy_guziki;
    }

    public Boolean getCzy_dlugi_rekaw() {
        return czy_dlugi_rekaw;
    }

    public void setCzy_dlugi_rekaw(Boolean czy_dlugi_rekaw) {
        this.czy_dlugi_rekaw = czy_dlugi_rekaw;
    }

    public String getRodzaj_kolnierzyka() {
        return rodzaj_kolnierzyka;
    }

    public void setRodzaj_kolnierzyka(String rodzaj_kolnierzyka) {
        this.rodzaj_kolnierzyka = rodzaj_kolnierzyka;
    }
}
