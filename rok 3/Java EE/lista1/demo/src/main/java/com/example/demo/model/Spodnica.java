package com.example.demo.model;

import jakarta.persistence.DiscriminatorValue;
import jakarta.persistence.Entity;

@Entity
@DiscriminatorValue("spodnica")
public class Spodnica extends Ubranie{
    private String rodzaj;
    private Boolean czy_dluga;

    public String getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(String rodzaj) {
        this.rodzaj = rodzaj;
    }

    public Boolean getCzy_dluga() {
        return czy_dluga;
    }

    public void setCzy_dluga(Boolean czy_dluga) {
        this.czy_dluga = czy_dluga;
    }
}
