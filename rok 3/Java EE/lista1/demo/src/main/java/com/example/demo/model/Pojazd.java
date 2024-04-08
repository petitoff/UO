package com.example.demo.model;

import jakarta.persistence.*;

@MappedSuperclass
public class Pojazd {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private Integer rocznik;
    private Integer przebieg;
    private String producent;
    private String kolor;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getRocznik() {
        return rocznik;
    }

    public void setRocznik(Integer rocznik) {
        this.rocznik = rocznik;
    }

    public Integer getPrzebieg() {
        return przebieg;
    }

    public void setPrzebieg(Integer przebieg) {
        this.przebieg = przebieg;
    }

    public String getProducent() {
        return producent;
    }

    public void setProducent(String producent) {
        this.producent = producent;
    }

    public String getKolor() {
        return kolor;
    }

    public void setKolor(String kolor) {
        this.kolor = kolor;
    }
}
